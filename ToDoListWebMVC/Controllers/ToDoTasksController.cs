﻿using System;
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

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoTask toDoTask)
        {
            if(!ModelState.IsValid)
            {
                return View(toDoTask);
            }

            await _toDoTaskService.InsertAsync(toDoTask);
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
        public async Task<IActionResult> Edit(ToDoTask toDoTask)
        {
            if (!ModelState.IsValid)
            {
                return View(toDoTask);
            }

            await _toDoTaskService.UpdateAsync(toDoTask);
            return RedirectToAction(nameof(Index));
        }
    }
}
