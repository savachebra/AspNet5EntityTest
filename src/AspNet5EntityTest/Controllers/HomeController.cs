using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using AspNet5EntityTest.ViewModels.Options;

namespace AspNet5EntityTest.Controllers
{
    public class HomeController : Controller
    {
        private HomeControllerOptions _options;

        public HomeController(IOptions<HomeControllerOptions> options)
        {
            _options = options.Value;
        }

        public IActionResult Index()
        {
            return View(_options);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
