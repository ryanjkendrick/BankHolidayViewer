using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankHolidayViewer.Models;

using BankHolidayAcquisition;

namespace BankHolidayViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankHolidayAcquirer _bankHolidayAcquirer;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _bankHolidayAcquirer = new BankHolidayAcquirer();
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

        [HttpGet]
        public IActionResult GetHolidays()
        {
            return Json(_bankHolidayAcquirer.GetBankHolData());
        }
    }
}
