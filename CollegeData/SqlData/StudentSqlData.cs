using CollegeCore;
using CollegeData.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CollegeData.SqlData
{
    public class StudentSqlData : IStudentData
    {
        private readonly CollegeDbContext dbContext;
        public StudentSqlData (CollegeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Student CreateStudent(Student student)
        {
            dbContext.Students.Add(student);
            return student;
        }

        public IEnumerable<Student> GetStudent()
        {
            return dbContext.Students
                .Include(x => x.Students)
                .ThenInclude(z => z.Subject)
                .ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return dbContext.Students
                .Include(x => x.Students)
                .ThenInclude(z => z.Subject)
                .SingleOrDefault(x => x.Id == studentId);
        }
    }
}
