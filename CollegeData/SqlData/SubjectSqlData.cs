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
    public class SubjectSqlData : ISubjectData
    {
        private readonly CollegeDbContext dbContext;
        public SubjectSqlData(CollegeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int commit()
        {
            return dbContext.SaveChanges();
        }

        public Subject CreateSubject(Subject subject)
        {
            dbContext.Subjects.Add(subject);
            return subject;
        }

        public Subject GetSubjectById(int subjectId)
        {
            return dbContext.Subjects
                .SingleOrDefault(x => x.Id == subjectId);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return dbContext.Subjects
                .Include(x => x.Students)
                .ThenInclude(z => z.Student)
                .ToList();
        }
    }
}
