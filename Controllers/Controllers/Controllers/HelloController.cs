using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers.Controllers
{
    [NonController]
    public class HelloController : Controller
    {
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
    }
}