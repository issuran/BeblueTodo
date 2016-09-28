using System.ComponentModel.DataAnnotations;

namespace BeBlueTodoApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}