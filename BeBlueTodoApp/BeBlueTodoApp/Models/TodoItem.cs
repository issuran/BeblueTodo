using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeBlueTodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string IsDone { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}