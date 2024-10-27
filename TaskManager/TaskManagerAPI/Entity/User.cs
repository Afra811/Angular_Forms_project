using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }

        public Address? Address { get; set; }
        
        public ICollection<TaskItem>? Tasks { get; set; } = new List<TaskItem>();
    }
}
