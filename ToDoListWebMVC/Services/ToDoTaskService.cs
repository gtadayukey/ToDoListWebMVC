using Microsoft.EntityFrameworkCore;
using ToDoListWebMVC.Data;
using ToDoListWebMVC.Models;

namespace ToDoListWebMVC.Services
{
    public class ToDoTaskService
    {
        private readonly ToDoListWebMVCContext _context;

        public ToDoTaskService(ToDoListWebMVCContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ToDoTask>> GetAllAsync()
        {
            return await _context.ToDoTask.OrderBy(x => x.Date).ToListAsync();
        }

        public async Task InsertAsync(ToDoTask toDoTask)
        {
            await _context.ToDoTask.AddAsync(toDoTask);
            _context.SaveChanges();
        }
    }
}
