using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloApp.Pages
{
    public class IndexModel : PageModel
    {
        // TODO: Service discovery
        private static readonly Uri HelloServiceEndpoint = new Uri(@"https://localhost:5001/hello/");
        private static readonly HttpClient HttpClient = new HttpClient();

        [BindProperty]
        [Required, StringLength(100)]
        public string Name { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var uri = new Uri(HelloServiceEndpoint, Name);
            Console.WriteLine($"Calling {uri}");
            var message = await HttpClient.GetStringAsync(uri);

            ViewData["Message"] = message;
            return Page();
        }
    }
}
