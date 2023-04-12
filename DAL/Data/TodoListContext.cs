using System.Data.Entity;
using DAL.Models;

namespace DAL.Data {
    public class TodoListContext: DbContext {

        public TodoListContext() : base("todo_entities") { }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}