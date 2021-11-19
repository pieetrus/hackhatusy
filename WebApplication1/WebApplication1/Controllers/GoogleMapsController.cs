using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GoogleMapsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabaseContext _context;

        public GoogleMapsController(ILogger<HomeController> logger, IDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
