namespace API.Migrations
{
    using DAL.Data;
    using DAL.Models;
    using MySql.Data.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());

        }

        protected override void Seed(TodoListContext context)
        {
            // Add two users
            var user1 = new User { Name = "John Doe", Email = "john.doe@example.com" };
            var user2 = new User { Name = "Alice Doe", Email = "alice.doe@example.com" };

            context.Users.AddOrUpdate(u => u.Id, user1, user2);

            // Add tasks for user1
            context.Tasks.AddOrUpdate(
                t => t.Id,
                new Task { Title = "Buy groceries", Description = "Milk, eggs, bread", DueDate = DateTime.Now.AddDays(1), IsCompleted = false, User = user1 },
                new Task { Title = "Pay bills", Description = "Electricity and water", DueDate = DateTime.Now.AddDays(2), IsCompleted = false, User = user1 }
            );

            // Add tasks for user2
            context.Tasks.AddOrUpdate(
                t => t.Id,
                new Task { Title = "Finish presentation", Description = "Prepare slides for the meeting", DueDate = DateTime.Now.AddDays(3), IsCompleted = false, User = user2 },
                new Task { Title = "Book flights", Description = "Book flights for the conference", DueDate = DateTime.Now.AddDays(4), IsCompleted = false, User = user2 }
            );

            context.SaveChanges();
        }
    }
}
