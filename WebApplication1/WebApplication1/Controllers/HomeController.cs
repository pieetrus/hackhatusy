using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabaseContext _context;
       

        public HomeController(ILogger<HomeController> logger, IDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Events
                .Include(x => x.Organizer)
                .Include(x => x.Category)
                .ToList();


            var viewModel = new EventsViewModel
            {
                Events = data
            };

            return View(viewModel);
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

        //public JsonResult GetMapMarker()
        //{   
        //    var ListOfAddress = _context.MapsAddresses.ToList();

        //    return Json(ListOfAddress, JsonRequestBehavior.AllowGet);
        //}
    }
}
