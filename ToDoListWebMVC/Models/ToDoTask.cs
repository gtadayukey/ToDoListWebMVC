namespace ToDoListWebMVC.Models
{
    public class ToDoTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }

        public ToDoTask() { }

        public ToDoTask(string title, string description, DateOnly date, TimeOnly time)
        {
            Title = title;
            Description = description;
            Date = date;
            Time = time;
        }
    }
}
