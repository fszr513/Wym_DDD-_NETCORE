using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult Jsonp()
        {
            string aa=HttpContext.Request.Query["callback"];
            var bb = new List<jsonp>
            {
                new jsonp{Id=1,Name="a2"},
                new jsonp{Id=2,Name="a3"},
                new jsonp{Id=3,Name="a4"}
            };
            var cc = JsonConvert.SerializeObject(bb);
            return Content($"{aa}({cc})");
        }
    }
}
