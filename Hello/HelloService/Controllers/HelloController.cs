using Microsoft.AspNetCore.Mvc;

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
