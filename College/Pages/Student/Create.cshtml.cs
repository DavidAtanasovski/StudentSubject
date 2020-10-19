using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CollegeCore;
using CollegeData.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace College.Pages.Student
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CollegeCore.Student Student { get; set; }
        [BindProperty, Display(Name = "Choose Subject")]
        public List<SelectListItem> AddSubject { get; set; }

        private readonly IStudentData studentData;
        private readonly ISubjectData subjectData;
        public CreateModel (IStudentData studentData, ISubjectData subjectData)
        {
            this.studentData = studentData;
            this.subjectData = subjectData;
        }

        public IActionResult OnGet()
        
        {
           

            Student = new CollegeCore.Student();
                
            
            AddSubject = subjectData.GetSubjects().Select(x => new SelectListItem
            {
                Selected = false,
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return Page();
        }

        public IActionResult OnPost()
        { 
            if  (ModelState.IsValid)
            {
                foreach (var subject in AddSubject)
                {
                    if ( subject.Selected)
                    {
                        Student.Students.Add(new Students
                        {
                            Subject = subjectData.GetSubjectById(Convert.ToInt32(subject.Value))
                        });
                    }
                }
                studentData.CreateStudent(Student);
                studentData.Commit();
                return RedirectToPage("./Detail", new { studentId = Student.Id });
            }


            AddSubject = subjectData.GetSubjects().Select(x => new SelectListItem
            {
                Selected = false,
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return Page();
        }
    }
}
