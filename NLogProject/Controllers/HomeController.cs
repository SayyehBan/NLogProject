using Microsoft.AspNetCore.Mvc;
using NLogProject.Models;
using System.Diagnostics;

namespace NLogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly NLog.Logger nlog = NLog.LogManager.GetCurrentClassLogger();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            for (int i = 0; i < 100; i++)
            {
                nlog.Info("test log");
                Sum(int.Parse("v"), int.Parse("s"));
            }

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

        int Sum(int a, int b)
        {
            try
            {
                nlog.Trace("Enter Sum");
                nlog.Debug($"a={a} and b={b}");
                int c = a + b;
                nlog.Debug($"c = a + b ==> {c}");
                nlog.Info("Sum Method run");
                return c;
            }
            catch (Exception ex)
            {
                nlog.Error("Error", ex);
                throw;
            }

        }
    }
}
