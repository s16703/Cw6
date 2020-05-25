using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw5.Models;

namespace Cw5.DAL
{
    public interface IDbServices
    {
        public IEnumerable<Student> GetStudents();

        public void AddStudent(Student s);

        public void RemoveStudent(int id);

        public void UpdateStudent(Student s, int id);

        public Student GetStudent(int id);

        public int ListLength();
    }
}
