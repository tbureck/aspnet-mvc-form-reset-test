using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TBureck.Test.CheckBoxes.Models;

namespace TBureck.Test.CheckBoxes.Controllers
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
            _logger.LogInformation("Render Index");
            return View(new CheckBoxTestModel());
        }

        [HttpPost("/test", Name = "PostTest")]
        public IActionResult PostTest(CheckBoxTestModel model)
        {
            _logger.LogInformation("Render PostTest");
            if (!ModelState.IsValid) {
                _logger.LogInformation("Model is invalid. Reset checkbox.");
                model.OptionalField = "";
                model.Accept = false;
                
                return this.View("Index", model);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}