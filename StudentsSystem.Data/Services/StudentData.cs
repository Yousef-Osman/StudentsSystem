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

        public  void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void EditStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<Field> GetAllFields()
        {
            return _context.Fields;
        }

        public IQueryable<Governorate> GetAllGovernorates()
        {
            return _context.Governorates;
        }

        public IQueryable<Neighborhood> GetAllNeighborhoods()
        {
            return _context.Neighborhoods;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return (await _context.Students.Include(s => s.Field).Include(s => s.Governorate).Include(s => s.Neighborhood).ToListAsync());
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }
    }
}
