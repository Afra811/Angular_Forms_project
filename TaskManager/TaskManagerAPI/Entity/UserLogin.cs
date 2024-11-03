using static TaskManagerAPI.Entity.UserRegister;

namespace TaskManagerAPI.Entity
{
    public class UserLogin
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public userRole Role { get; set; }
    }
}
