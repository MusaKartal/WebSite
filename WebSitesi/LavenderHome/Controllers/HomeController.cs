using LavenderHome.Business.Abstract;
using LavenderHome.Infrastructure;
using LavenderHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LavenderHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _homeService;
        private readonly IService _adminService;
        public HomeController(IContactService homeService, IService adminService)
        {
            this._adminService = adminService;
            this._homeService = homeService;
        }

        public async Task <IActionResult> Index()
        {
            var products = await _adminService.GetAllItemsAsync();
            return View(products);
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

        public async Task<IActionResult>Tailor()
        {
            var products = await _adminService.GetAllItemsAsync();
            return View(products);
        }

        public async Task<IActionResult> Cleaning()
        {
            var products = await _adminService.GetAllItemsAsync();
            return View(products);
        }

        public async Task<IActionResult> About()
        {

            return View();
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(Contact model)
        {
            var contact = await _homeService.CreateItemAsync(model);

            return RedirectToAction("Index");
        }

    }
}
