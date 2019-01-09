using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHelloServiceClient _helloServiceClient;

        [BindProperty]
        [Required, StringLength(100)]
        public string Name { get; set; }

        public IndexModel(IHelloServiceClient helloServiceClient)
        {
            _helloServiceClient = helloServiceClient ?? throw new ArgumentNullException(nameof(helloServiceClient));
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ViewData["Message"] = await _helloServiceClient.GetMessage(Name);
            return Page();
        }
    }
}
