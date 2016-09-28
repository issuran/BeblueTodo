namespace BeBlueTodoApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BeBlueTodoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BeBlueTodoApp.Models.BeBlueTodoAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeBlueTodoApp.Models.BeBlueTodoAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.People.AddOrUpdate(x => x.Id,
                new Person() { Id = 1, Name = "Maiko" },
                new Person() { Id = 2, Name = "Curti" },
                new Person() { Id = 3, Name = "Oliveira" },
                new Person() { Id = 4, Name = "Massita" }
                );
            context.TodoItems.AddOrUpdate(x => x.Id,
                new TodoItem() { Id = 1, Description = "Buy it", IsDone = "In Progress", PersonId = 3 },
                new TodoItem() { Id = 2, Description = "Use it", IsDone = "In Progress", PersonId = 1 },
                new TodoItem() { Id = 3, Description = "Break it", IsDone = "Done", PersonId = 2 },
                new TodoItem() { Id = 4, Description = "Fix us", IsDone = "In Progress", PersonId = 2 },
                new TodoItem() { Id = 5, Description = "Trash it", IsDone = "Done", PersonId = 4 }
                );
        }
    }
}
