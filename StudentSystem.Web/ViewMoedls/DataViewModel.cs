using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Web.ViewMoedls
{
    public class DataViewModel
    {
        public IEnumerable<Student> Students { get; set; }
    }
}