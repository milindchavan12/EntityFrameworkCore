using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EfCore.WebApp.Models;
using EFCore.Data;
using EFCore.Domain;

namespace EfCore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var samuraiContext = new SamuraiContext())
            {
                var samurai = new Samurai()
                {
                    Id = 1,
                    Name = "Nijna"
                };
                samuraiContext.Samurais.Add(samurai);
                samuraiContext.SaveChanges();
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
    }
}
