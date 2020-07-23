using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.ViewMoedls
{
    public class DataViewModel
    {
        private readonly ArmyTechDB _context;

        public DataViewModel()
        {
            _context = new ArmyTechDB();

            FieldId = new SelectList(_context.Fields, "Id", "Name");
            GovernorateId = new SelectList(_context.Governorates, "Id", "Name");
            NeighborhoodId = new SelectList(_context.Neighborhoods, "Id", "Name");
        }

        public SelectList FieldId { get; set; }
        public SelectList GovernorateId { get; set; }
        public SelectList NeighborhoodId { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public Student Student { get; set; }
    }
}