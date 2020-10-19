using CollegeCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeData.Interface
{
    public interface ISubjectData
    {
        Subject CreateSubject(Subject subject);
        Subject GetSubjectById(int subjectId);
        IEnumerable<Subject> GetSubjects();
        int commit();
    }
}
