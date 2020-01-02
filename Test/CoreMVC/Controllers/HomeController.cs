using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CeShiContext _context;

        public HomeController(ILogger<HomeController> logger , CeShiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Session.Id"] = HttpContext.Session.Id;
            ViewData["Session.Keys"] = HttpContext.Session.Keys;
            ViewData["Session.IsAvailable"] = HttpContext.Session.IsAvailable;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Time")))
            {
                HttpContext.Session.SetString("Time", DateTime.Now.ToString());
            }
            ViewData["Session.Time"] = HttpContext.Session.GetString("Time");

            var a = await _context.LC_Tests.AsNoTracking().FirstOrDefaultAsync(m => m.ID == 1);
            string obj = System.Text.Json.JsonSerializer.Serialize(a);
            ViewData["obj"] = obj;
            string coo;
            HttpContext.Request.Cookies.TryGetValue(".AspNetCore.Session", out coo);
            HttpContext.Response.Cookies.Append("CCTSession", "1234567890", new CookieOptions { HttpOnly = true });
            ViewData["coo"] = coo;
            return View();
        }

        public async Task<IActionResult> IndexAjax()
        {
            var sessionId = HttpContext.Session.Id;
            var sessionKeys = HttpContext.Session.Keys;
            var sessionIsAvailable = HttpContext.Session.IsAvailable;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Time")))
            {
                HttpContext.Session.SetString("Time", DateTime.Now.ToString());
            }
            var sessionTime = HttpContext.Session.GetString("Time");

            var a = await _context.LC_Tests.AsNoTracking().FirstOrDefaultAsync(m => m.ID == 1);
            //string obj = System.Text.Json.JsonSerializer.Serialize(a);
            //ViewData["obj"] = obj;
            string coo;
            HttpContext.Request.Cookies.TryGetValue(".AspNetCore.Session", out coo);
            //ViewData["coo"] = coo;
            return Json(new { sessionId, sessionKeys , sessionIsAvailable , sessionTime, a , coo });
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
}
