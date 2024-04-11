using Microsoft.EntityFrameworkCore;
using System.Data;
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

        public async Task InsertAsync(ToDoTask task)
        {
            await _context.ToDoTask.AddAsync(task);
            _context.SaveChanges();
        }

        public async Task<ToDoTask> GetByIdAsync(int id)
        {
            return await _context.ToDoTask.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ToDoTask task)
        {
            bool hasAny = await _context.ToDoTask.AnyAsync(x => x.Id == task.Id);

            if (!hasAny)
            {
                return;
            }

            _context.Update(task);
            await _context.SaveChangesAsync();
        }

        internal async Task RemoveAsync(int id)
        {
            var task = await GetByIdAsync(id);
            _context.ToDoTask.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
