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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoTask task)
        {
            if(!ModelState.IsValid)
            {
                return View(task);
            }

            await _toDoTaskService.InsertAsync(task);
            return RedirectToAction(nameof(Index)); 
        }

        // GET - READ
        public async Task<IActionResult> Details(int id)
        {
            ToDoTask task = await _toDoTaskService.GetByIdAsync(id);
            return View(task);
        }

        // GET - UPDATE
        public async Task<IActionResult> Edit(int id)
        {
            ToDoTask task = await _toDoTaskService.GetByIdAsync(id);
            return View(task);
        }

        // POST - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToDoTask task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }

            await _toDoTaskService.UpdateAsync(task);
            return RedirectToAction(nameof(Index));
        }

        // GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoTask task = await _toDoTaskService.GetByIdAsync(id.Value);

            if(task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _toDoTaskService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
