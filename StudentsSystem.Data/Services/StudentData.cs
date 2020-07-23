using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Data.Services
{
    public class StudentData : IStudentData
    {
        private readonly ArmyTechDB _context;

        public StudentData(ArmyTechDB context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void EditStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return (await _context.Students.Include(s => s.Field).Include(s => s.Governorate).Include(s => s.Neighborhood).ToListAsync());
        }

        public Student GetStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
