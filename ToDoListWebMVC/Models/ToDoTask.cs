using System.ComponentModel.DataAnnotations;
using ToDoListWebMVC.Models.ValidationAttributes;

namespace ToDoListWebMVC.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Title { get; set; }

        [DisplayFormat(NullDisplayText = "No Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Date)]
        [FutureDate("Date")]
        public DateOnly Date { get; set; }

        [DisplayFormat(NullDisplayText = "Without Time")]
        [DataType(DataType.Time)]
        public TimeOnly? Time { get; set; }

        public ToDoTask() {}

        public ToDoTask(string title, string description, DateOnly date, TimeOnly time)
        {
            Title = title;
            Description = description;
            Date = date;
            Time = time;
        }
    }
}
