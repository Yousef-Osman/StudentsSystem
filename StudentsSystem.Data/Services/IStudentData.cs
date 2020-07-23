using StudentsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Data.Services
{
    public interface IStudentData
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Student GetStudent(int id);
        void AddStudent(Student student);
        void EditStudent(Student student);
        void DeleteStudent(int id);
    }
}
