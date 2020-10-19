using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeCore
{
    public class Students
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
