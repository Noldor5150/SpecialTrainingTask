using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecialTrainingTask.Models;

namespace SpecialTrainingTask.Controllers
{
    public class ToDoItemController : Controller
        
    {
        private static List<ToDoItem> TodoList = new List<ToDoItem>
        {
            new ToDoItem{Id = 1, Name = "watewa", Description = "do homework"}
        };
        // GET: ToDoItem
        public ActionResult Index()
        {
            return View(TodoList);
        }

        // GET: ToDoItem/Details/5
        public ActionResult Details(int id)
        {
            return View(TodoList.FirstOrDefault(todo => todo.Id == id));
        }

        // GET: ToDoItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoItem todo)
        {
            try
            {
                TodoList.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(todo);
            }
        }

        // GET: ToDoItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View(TodoList.FirstOrDefault(todo => todo.Id == id));
        }

        // POST: ToDoItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToDoItem todo)
        {
            try
            {
                TodoList.RemoveAll(t => t.Id == id);
                TodoList.Add(todo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDoItem/Delete/5
        public ActionResult Delete(int id, ToDoItem todo)
        {
            return View(TodoList.FirstOrDefault(todo => todo.Id == id));
        }

        // POST: ToDoItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                TodoList.RemoveAll(t => t.Id == id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}