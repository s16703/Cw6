using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw5.Models;

namespace Cw5.Services
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(string indexNumber);
    }
}
