using Microsoft.AspNetCore.Mvc;
using Newspaper_CMS.Models;
using System.Diagnostics;

namespace Newspaper_CMS.Controllers
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
        public IActionResult UserHomePage()
        {
            if (User.IsInRole("Admin"))
            {
                return LocalRedirect("/Articles/AdminHomePage");

            }
            else if (User.IsInRole("Writer"))
            {
                return LocalRedirect("/Articles/WriterHomePage");
            }
            else
            {
                return LocalRedirect("/Articles/Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}