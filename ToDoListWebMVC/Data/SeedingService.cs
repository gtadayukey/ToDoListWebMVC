using ToDoListWebMVC.Models;

namespace ToDoListWebMVC.Data
{
    public class SeedingService
    {
        private readonly ToDoListWebMVCContext _context;

        public SeedingService(ToDoListWebMVCContext context) 
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.ToDoTask.Any()) 
            {
                return;
            }

            ToDoTask t1 = new("Title 1", "This is a description for Title 1 Task", new DateOnly(2024, 04, 18), new TimeOnly(17, 30));
            ToDoTask t2 = new("Title 2", "This is a description for Title 2 Task", new DateOnly(2024, 05, 4), new TimeOnly(15, 00));
            ToDoTask t3 = new("Title 3", "This is a description for Title 3 Task", new DateOnly(2024, 06, 2), new TimeOnly(7, 30));
            ToDoTask t4 = new("Title 4", "This is a description for Title 4 Task", new DateOnly(2024, 07, 20), new TimeOnly(8, 30));
            ToDoTask t5 = new("Title 5", "This is a description for Title 5 Task", new DateOnly(2024, 04, 25), new TimeOnly(9, 00));
            ToDoTask t6 = new("Title 6", "This is a description for Title 6 Task", new DateOnly(2024, 05, 12), new TimeOnly(12, 30));
            ToDoTask t7 = new("Title 7", "This is a description for Title 7 Task", new DateOnly(2024, 05, 28), new TimeOnly(22, 30));
            ToDoTask t8 = new("Title 8", "This is a description for Title 8 Task", new DateOnly(2024, 05, 14), new TimeOnly(20, 00));
            ToDoTask t9 = new("Title 9", "This is a description for Title 9 Task", new DateOnly(2024, 06, 1), new TimeOnly(14, 00));
            ToDoTask t10 = new("Title 10", "This is a description for Title 10 Task", new DateOnly(2024, 04, 29), new TimeOnly(14, 30));

            _context.ToDoTask.AddRange(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            _context.SaveChanges();
        }
    }
}
