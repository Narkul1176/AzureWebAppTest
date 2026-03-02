using System.Diagnostics;
using AzureWebAppTest.Models;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureWebAppTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public HomeController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Privacy()
        {
            ViewBag.msg1 = _config.GetSection("Message1").Value;
            ViewBag.msg2 = _config.GetSection("Message2").Value;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
