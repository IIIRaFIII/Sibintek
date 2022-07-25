using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        //Создаем свойство 
        private readonly ApplicationDbContext _db;

        //Получаем ссылку db для св-ва. Получаем доступ к бд через параметр _db
        public TaskController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Task> objList = _db.Task;
            foreach (var obj in objList)
                {
                    obj.Employee = _db.Employee.FirstOrDefault(u => u.Id == obj.EmployeeId);
                };
            return View(objList);
        }

        //GET-CREATE
        public IActionResult Create()
        { 

            IEnumerable<SelectListItem> EmployeeDropDown = _db.Employee.Select(i => new SelectListItem
            {

                Text = i.FullName,
                Value = i.Id.ToString()
            });

            ViewBag.EmployeeDropDown = EmployeeDropDown;

            return View();
        }
         
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Task obj)
        {
            obj.Employee = _db.Employee.FirstOrDefault(e => e.Id == obj.EmployeeId);
            obj.Name = obj.Name.Replace("<p>", "").Replace("</p>", "");
            obj.Status = false;
            if (ModelState.IsValid)
            {

                _db.Task.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET-EDIT
        public IActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> EmployeeDropDown = _db.Employee.Select(i => new SelectListItem
            {

                Text = i.FullName,
                Value = i.Id.ToString()
            });

            ViewBag.EmployeeDropDown = EmployeeDropDown;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Task.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Task obj)
        {
            if (ModelState.IsValid)
            {
                _db.Task.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET-DELETE 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Task.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            var obj = _db.Task.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Task.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //////////////////////////////////////////////////////////////////

        public IActionResult Change(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Task.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            obj.Status = true;
            _db.Task.Update(obj);
            _db.SaveChanges();
            
            return RedirectToAction("Index");

        }

      
    }
}
