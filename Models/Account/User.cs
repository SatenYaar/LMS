namespace LMS.Models.Account
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string UserType { get; set; }
        

    }
}
