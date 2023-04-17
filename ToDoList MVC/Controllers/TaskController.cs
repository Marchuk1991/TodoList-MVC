using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList_MVC.Models;

namespace TodoList_MVC.Controllers
{
    public class TaskController : Controller
    {
        private TodoListContext context;

        public TaskController (TodoListContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var tasks = context.Tasks.Include(t => t.Category).ToList();

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Create(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Add(task);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(task);
        }

        public IActionResult Create()
        {
            ViewBag.TaskCategories = new SelectList(context.Categories, "Id", "Name");
            return View();
        }

        public IActionResult Details(int id)
        {
            var task = context.Tasks.Include(t => t.Category).FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }
            ViewBag.TaskCategories = new SelectList(context.Categories, "Id", "Name");
            return View(task);
        }


        [HttpPost]
        public IActionResult Edit(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                context.Tasks.Update(task);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TaskCategories = new SelectList(context.Categories, "Id", "Name");
            return View(task);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            context.Tasks.Remove(task);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
