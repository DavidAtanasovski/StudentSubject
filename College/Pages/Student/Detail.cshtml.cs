using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeData.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace College.Pages.Student
{
    public class DetailModel : PageModel
    {
        private readonly IStudentData studentData;
        public IEnumerable<CollegeCore.Student> Students { get; set; }
         public DetailModel (IStudentData studentData)
        {
            this.studentData = studentData;          
        }

        public IActionResult OnGet()
        {
            Students = studentData.GetStudent();
           
            return Page();
        }
    }
}
