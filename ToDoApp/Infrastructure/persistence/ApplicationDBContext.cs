using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.model;

namespace ToDoApp.Infrastructure.persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDo>().Property(x => x.Title).HasMaxLength(150);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDo { get; set; }

    }
}
