using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollegeCore
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Mobile { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public List <Students> Students { get; set; }
        public Student()
        {
            Students = new List<Students>();
        }
    }
}
