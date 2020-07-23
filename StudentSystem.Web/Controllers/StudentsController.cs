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
    }
}