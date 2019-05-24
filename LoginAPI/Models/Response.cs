namespace LoginAPI.Models
{
    public class Response
    {
        public string Status { set; get; }
        public string Message { set; get; }
        public string token { set; get; }

    }
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string token { get; set; }
        public string Status { get; set; }
    }
}