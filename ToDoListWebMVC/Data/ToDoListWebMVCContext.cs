using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoListWebMVC.Models;

namespace ToDoListWebMVC.Data
{
    public class ToDoListWebMVCContext : DbContext
    {
        public ToDoListWebMVCContext (DbContextOptions<ToDoListWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoTask> ToDoTask { get; set; } = default!;
    }
}
