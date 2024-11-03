namespace TaskManagerAPI.Entity
{
    public class UserRegister
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public enum userRole
        {
            User,
            Admin,
            Viewer
        };

        public userRole Role { get; set; }
    }
}
