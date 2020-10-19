using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeData.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace College.Pages.Subject
{
    public class DetailModel : PageModel
    {
        public IEnumerable<CollegeCore.Subject> Subjects { get; set; }
        private readonly ISubjectData subjectData;

        public DetailModel (ISubjectData subjectData)
        {
            this.subjectData = subjectData;
        }

        public IActionResult OnGet()
        {
            Subjects = subjectData.GetSubjects();

            return Page();
        }
    }
}
