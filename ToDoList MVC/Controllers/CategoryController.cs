using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList_MVC.Models;

namespace TodoList_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private TodoListContext context;

        public CategoryController(TodoListContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = context.Categories.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = context.Categories.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            context.Categories.Remove(task);
            context.SaveChanges();
            return RedirectToAction("Index");
        }









        public IActionResult Details(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}
