using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListWebMVC.Data;
using ToDoListWebMVC.Models;

namespace ToDoListWebMVC.Controllers
{
    public class ToDoTasksController : Controller
    {
        private readonly ToDoListWebMVCContext _context;

        public ToDoTasksController(ToDoListWebMVCContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
