using System.ComponentModel.DataAnnotations;

namespace To_Do.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}