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

        // GET - READ
        public async Task<ICollection<ToDoTask>> GetAllAsync()
        {
            return await _context.ToDoTask.OrderBy(x => x.Date).ToListAsync();
        }
    }
}
