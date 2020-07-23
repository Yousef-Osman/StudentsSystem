using StudentsSystem.Data.Models;
using StudentsSystem.Data.Services;
using StudentSystem.Web.ViewMoedls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentData _studentData;

        public StudentsController(IStudentData studentData)
        {
            _studentData = studentData;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _studentData.GetAllStudents();
            return View(model);
        }

        public ActionResult AddStudent()
        {
            ViewBag.FieldId = new SelectList(_studentData.GetAllFields(), "ID", "Name");
            ViewBag.GovernorateId = new SelectList(_studentData.GetAllGovernorates(), "ID", "Name");
            ViewBag.NeighborhoodId = new SelectList(_studentData.GetAllNeighborhoods(), "ID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentData.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(AddStudent));
        }

        public async Task<ActionResult> EditStudent(int id)
        {
            var student = await _studentData.GetStudent(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.FieldId = new SelectList(_studentData.GetAllFields(), "ID", "Name");
            ViewBag.GovernorateId = new SelectList(_studentData.GetAllGovernorates(), "ID", "Name");
            ViewBag.NeighborhoodId = new SelectList(_studentData.GetAllNeighborhoods(), "ID", "Name");

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentData.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(EditStudent));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(int id)
        {
            _studentData.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
