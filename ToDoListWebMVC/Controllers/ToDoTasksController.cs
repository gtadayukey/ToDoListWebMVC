using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using NuGet.Protocol.Plugins;
using ToDoListWebMVC.Data;
using ToDoListWebMVC.Models;
using ToDoListWebMVC.Models.ViewModels;
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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id not provided" });
            }

            ToDoTask task = await _toDoTaskService.GetByIdAsync(id.Value);

            if (task == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id not found" });
            }

            return View(task);
        }

        // GET - UPDATE
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id not provided" });
            }

            ToDoTask task = await _toDoTaskService.GetByIdAsync(id.Value);

            if (task == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id not found" });
            }

            return View(task);
        }

        // POST - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoTask task)
        {
            if (!ModelState.IsValid)
            {
                return View(task);
            }

            if (id != task.Id)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id mismatch" });
            }

            try
            {
                await _toDoTaskService.UpdateAsync(task);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { msg = e.Message });
            }
        }

        // GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { msg = "Id not found" });
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

        public IActionResult Error(string msg)
        {
            var viewModel = new ErrorViewModel
            {
                ErrorMessage = msg,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
