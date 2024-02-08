using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<TaskToDo> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskToDo>().HasData(new TaskToDo
            {
                Id = 1,
                Title = "Teste Trendx",
                Description = "Realizar o teste para a empresa Trendx",
                Completed = true
            });
        }
    }
}
