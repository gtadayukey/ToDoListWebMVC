using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListWebMVC.Data;
using ToDoListWebMVC.Models;
using ToDoListWebMVC.Services;

namespace ToDoListWebMVC.Controllers
{
    public class ToDoTasksController : Controller
    {
        private readonly ToDoListWebMVCContext _context;
        private readonly ToDoTaskService _toDoTaskService;

        public ToDoTasksController(ToDoListWebMVCContext context, ToDoTaskService toDoTaskService)
        {
            _context = context;
            _toDoTaskService = toDoTaskService;
        }

        public async Task<IActionResult> Index()
        {
            var listToDoTasks = await _toDoTaskService.GetAllAsync();
            return View(listToDoTasks);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
