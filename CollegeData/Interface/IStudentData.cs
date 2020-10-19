using CollegeCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeData.Interface
{
    public interface IStudentData
    {
        Student CreateStudent(Student student);
        Student GetStudentById(int studentId);
        IEnumerable<Student> GetStudent();
        int Commit();
    }
}
