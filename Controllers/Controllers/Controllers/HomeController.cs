using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Controllers.Models;
using Controllers.Util;

namespace Controllers.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult GetUser()
        {
            User user = new User { Name = "Tom", Age = 28 };
            return Json(user);
        }

        [NonAction]
        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET 5</h2>");
        }

        [NonAction]
        public string Area()
        {
            string altitudeString = Request.Query.FirstOrDefault(p => p.Key == "altitude").Value;
            int altitude = Int32.Parse(altitudeString);

            string heightString = Request.Query.FirstOrDefault(p => p.Key == "height").Value;
            int height = Int32.Parse(heightString);

            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        }

        [NonAction]
        public string Sum(Geometry[] geoms)
        {
            return $"Сумма площадей равна {geoms.Sum(g => g.GetArea())}";
        }

        [NonAction]
        [HttpPost]
        public IActionResult Area(int altitude, int height)
        {
            double area = altitude * height / 2;
            return Content($"Площадь треугольника с основанием {altitude} и высотой {height} равна {area}");
        }

        [NonAction]
        public string Square(int a, int h)
        {
            double s = a * h / 2;
            return $"Площадь треугольника с основанием {a} и высотой {h} равна {s}";
        }

        [NonAction]
        public string Hello(int id)
        {
            return $"id= {id}";
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
    public class Geometry
    {
        public int Altitude { get; set; } // основание
        public int Height { get; set; } // высота

        public double GetArea() // вычисление площади треугольника
        {
            return Altitude * Height / 2;
        }
    }
}
