using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required, StringLength(100)]
        public string Name { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ViewData["Message"] = $"Hello {Name}";
            return Page();
        }
    }
}
