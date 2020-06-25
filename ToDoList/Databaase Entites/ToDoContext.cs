using System.Data.Entity;

namespace ToDoList
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("ToDoList")
        { }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}