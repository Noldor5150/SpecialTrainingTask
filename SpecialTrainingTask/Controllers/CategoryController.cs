using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecialTrainingTask.Models;

namespace SpecialTrainingTask.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> CategoryList = new List<Category>
        {
           new Category { Id = 1, Name = "Action" }
        };
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(CategoryList);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(CategoryList.FirstOrDefault(category => category.Id == id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                CategoryList.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(CategoryList);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CategoryList.FirstOrDefault(category => category.Id == id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                CategoryList.RemoveAll(c => c.Id == id);
                CategoryList.Add(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CategoryList.FirstOrDefault(category => category.Id == id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                CategoryList.RemoveAll(cate => cate.Id == id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}