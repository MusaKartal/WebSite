using AutoMapper;
using LavenderHome.Business.Abstract;
using LavenderHome.Business.Services;
using LavenderHome.Infrastructure;
using LavenderHome.Models;
using LavenderHome.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LavenderHome.Controllers
{
    public class AdminController : Controller
    {
        private readonly IContactService _homeService;
        private readonly IService _adminService;
        public AdminController(IContactService homeService, IService adminService)
        {
            this._adminService = adminService;
            this._homeService = homeService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _adminService.GetAllItemsAsync();       
            return View(products);

        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult>Post()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>Post(IFormFile file, Product model)
        {
            

            if(file != null)
            {
                await _adminService.ImageItemAsync(file, model);
            }
            else
            {

                await _adminService.CreateItemAsync(model);
            }
           
            return RedirectToAction("Get");
        }

        [Authorize]
        [HttpPost] 
        public async Task<IActionResult> Delete(Product model)
        { 
            await _adminService.DeleteItemAsync(model);
            return RedirectToAction("Get");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(Product model)
        {
            var product = await _adminService.GetItemByIdAsync(model.Id);         
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> Edit(Product model)
        {
            var productId = await _adminService.GetItemByIdAsync(model.Id);

            return View(productId);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile file, int id ,Product model)
        {        
            await _adminService.UpdateItemAsync(file,id,model);
            return RedirectToAction("Get");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var contact = await _homeService.GetAllItemsAsync();
            return View(contact);

        }

       



    }
}
