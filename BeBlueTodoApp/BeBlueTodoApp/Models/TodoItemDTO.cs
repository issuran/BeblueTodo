using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeBlueTodoApp.Models
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IsDone { get; set; }
        public string PersonName { get; set; }
    }
}