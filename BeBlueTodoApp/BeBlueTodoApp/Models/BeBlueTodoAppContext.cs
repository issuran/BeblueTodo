using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeBlueTodoApp.Models
{
    public class BeBlueTodoAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BeBlueTodoAppContext() : base("name=BeBlueTodoAppContext")
        {
        }

        public System.Data.Entity.DbSet<BeBlueTodoApp.Models.TodoItem> TodoItems { get; set; }

        public System.Data.Entity.DbSet<BeBlueTodoApp.Models.Person> People { get; set; }
    }
}
