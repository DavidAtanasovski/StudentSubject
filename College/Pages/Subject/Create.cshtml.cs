using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeData.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace College.Pages.Subject
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CollegeCore.Subject Subject { get; set; }

        private readonly ISubjectData subjectData;

        public CreateModel (ISubjectData subjectData)
        {
            this.subjectData = subjectData;
        }

        public IActionResult OnGet()
        {
            Subject = new CollegeCore.Subject();
            
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            { 
            subjectData.CreateSubject(Subject);
            subjectData.commit();
                return RedirectToPage("./Detail", new { subjectId = Subject.Id });
             }

            return Page();
        }


    }
}
