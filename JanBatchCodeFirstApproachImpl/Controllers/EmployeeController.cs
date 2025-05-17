using JanBatchCodeFirstApproachImpl.Data;
using JanBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;

namespace JanBatchCodeFirstApproachImpl.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext db;

        public EmployeeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Emps.ToList();
            return View(data);
        }

        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(e);
                db.SaveChanges();
                TempData["success"] = "Employee Added Successfully!!";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeleteEmp(int id)
        {
            var data = db.Emps.Where(x => x.eid == id).SingleOrDefault();
            //var data = db.Emps.Find(id);
            if (data != null)
            {
                db.Emps.Remove(data);
                db.SaveChanges();
            }
            TempData["error"] = "Employee Deleted Successfully!!";
            return RedirectToAction("Index");
        }

        public IActionResult EditEmp(int id)
        {
            var data = db.Emps.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditEmp(Emp e)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Update(e);
                db.SaveChanges();
            TempData["update"] = "Employee Updated Successfully!!";
                return RedirectToAction("Index");
            }
            return View(e);
        }
    }
}
