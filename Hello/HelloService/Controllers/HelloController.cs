using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloService.Controllers
{
    [Route("[controller]")]
    public class HelloController : Controller
    {
        // GET hello/world
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return $"Hello {name}";
        }
    }
}
