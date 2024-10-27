using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Entity;

namespace TaskManagerAPI.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Address)
                .WithOne(u => u.User)
                .HasForeignKey<Address>(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                  

            modelBuilder.Entity<User>()
                .HasMany(o => o.Tasks)
                .WithOne(p => p.Assignee)
                .HasForeignKey(o => o.AssigneeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
