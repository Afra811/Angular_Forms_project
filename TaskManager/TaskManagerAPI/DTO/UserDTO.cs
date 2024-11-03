namespace TaskManagerAPI.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
