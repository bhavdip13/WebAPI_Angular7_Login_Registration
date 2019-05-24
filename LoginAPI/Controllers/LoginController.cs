using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace LoginAPI.Controllers
{
    public class LoginController : ApiController
    {
        EmployeeEntities DB = new EmployeeEntities();
        [Route("Api/Login/createcontact")]
        [HttpPost]
        public object createcontact(Registration Lvm)
        {
            try
            {

                Employeemaster Em = new Employeemaster();
                if (Em.UserId == 0)
                {

                    Em.Password = Lvm.Password;
                    Em.Email = Lvm.Email;
                    Em.ContactNo = Lvm.ContactNo;
                    Em.City = Lvm.City;
                    Em.Address = Lvm.Address;
                    Em.Site = Lvm.Site;
                    Em.Dob = Convert.ToDateTime(Lvm.Dob);
                    Em.Gender = Lvm.Gender;
                    Em.Skills = Lvm.Skills;
                    Em.Profile = Convert.FromBase64String(Lvm.Profile.Split(',')[1].Replace('-', '+'));
                    Em.IsApporved = 1;
                    Em.LoginTryCnt = 0; // login try count after the wrong username and password.
                    Em.Status = 1; //for login try attamt more than 5 then block login button.
                    DB.Employeemasters.Add(Em);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
        [Route("Api/Login/UpdateUser")]
        [HttpPost]
        public object UpdateUser(Registration Lvm)
        {
            try
            {

                Employeemaster Em = new Employeemaster();
                Em = DB.Employeemasters.Find(Lvm.UserId);
                if (Lvm.UserId != 0)
                {

                    Em.UserId = Lvm.UserId;
                    Em.City = Lvm.City;
                    Em.Address = Lvm.Address;
                    Em.Site = Lvm.Site;
                    Em.ContactNo = Lvm.ContactNo;
                    Em.Dob = Convert.ToDateTime(Lvm.Dob);
                    Em.Gender = Lvm.Gender;
                    Em.Skills = Lvm.Skills;
                    Em.Profile = Convert.FromBase64String(Lvm.Profile.Split(',')[1].Replace('-', '+'));
                    DB.Entry(Em).State = EntityState.Modified;
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Updated." };
                }
            }
            catch (Exception ex)
            {

            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
        [Route("Api/Login/DeleteUser/{UserId}")]
        [HttpDelete]
        public object DeleteUser(int UserId)
        {
            try
            {
                Employeemaster Em = DB.Employeemasters.Find(UserId);
                DB.Employeemasters.Remove(Em);
                DB.SaveChanges();
                return new Response
                { Status = "Success", Message = "Recored successfully deleted." };

            }
            catch (Exception ex)
            {
                return new Response
                { Status = "Error", Message = "Invalid Data." };

            }

        }
        [Route("Api/Login/UserLogin")]
        [HttpPost]
        public Response Login(Login Lg)
        {

            var Obj = DB.Usp_Login(Lg.UserName, Lg.Password).ToList<Usp_Login_Result>().FirstOrDefault();
            if (Obj.Status == 0)
                return new Response { Status = "Invalid", Message = "Invalid User.", token = Obj.token };
            if (Obj.Status == -1)
                return new Response { Status = "Inactive", Message = "User Inactive.", token = Obj.token };
            else
                return new Response { Status = "Success", Message = Lg.UserName, token = Obj.token };
        }
        [Route("Api/Login/UserLogin2")]
        [HttpPost]
        public User Login(string Email, string Password)
        {

            var Obj = DB.Usp_Login(Email, Password).ToList<Usp_Login_Result>().FirstOrDefault();
            if (Obj.Status == 0)
                return new User { UserId = Obj.UserId, Email = Obj.Email, token = Obj.token, Status = "Invalid" };
            if (Obj.Status == -1)
                return new User { UserId = Obj.UserId, Email = Obj.Email, token = Obj.token, Status = "MaxLoginTryLimitCross" };
            if (Obj.IsApporved == 0)
                return new User { UserId = Obj.UserId, Email = Obj.Email, token = Obj.token, Status = "Inactive" };
            else
                return new User { UserId = Obj.UserId, Email = Obj.Email, token = Obj.token, Status = "Success" };

        }
        [Route("Api/Login/isEmailRegisterd")]
        [HttpGet]
        public bool isEmailRegisterd(string email)
        {
            if (DB.Employeemasters.Where(x => x.Email == email).FirstOrDefault() != null)
                return false;

            else
                return true;
        }
        [Route("Api/Login/GetAllUser")]
        [HttpGet]
        public List<Employeemaster> GetAllUser()
        {
            return DB.Employeemasters.ToList();
        }

    }
}
