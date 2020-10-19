using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeCore
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int Semester { get; set; }

        public List<Students> Students { get; set; }
        public Subject()
        {
            Students = new List<Students>();
        }
    }
}
