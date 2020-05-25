using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw5.DTOs.Requests;
using Cw5.DTOs.Responses;
using Cw5.Models;

namespace Cw5.Services
{
    public interface IStudentDbService
    {
        Student GetStudent(string index);
        public void EnrollStudent(EnrollStudentRequest request);
        public Enrollment PromoteStudents(int semester, int studies);
    }
}
