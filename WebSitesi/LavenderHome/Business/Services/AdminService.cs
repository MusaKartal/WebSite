using AutoMapper;
using LavenderHome.Business.Abstract;
using LavenderHome.Data;
using LavenderHome.Infrastructure;
using LavenderHome.Models;
using LavenderHome.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LavenderHome.Business.Services
{
    public class AdminService : IService
    {
        protected readonly IGenericRepository<Product> _repository;
        private readonly IMapper mapper;
        private readonly ILogger<AdminService> logger;
        public AdminService(IGenericRepository<Product> repository, IMapper _mapper, ILogger<AdminService> _logger)
        {
            _repository = repository;
            mapper = _mapper;
            logger = _logger;
        }


        public async Task<int> CreateItemAsync(Product newProduct)
        {
            try
            {
                var user = mapper.Map<Product>(newProduct);
                await _repository.CreateAsync(user);
                return user.Id;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Exception Error During Add User", newProduct);
                throw e;
            }

        }

        public async Task DeleteItemAsync(Product Product)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{Product.Photo}");

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            await _repository.DeleteAsync(Product.Id);

        }

        public async Task<IEnumerable<Product>> GetAllItemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetItemByIdAsync(int id)
        {
            return await _repository.GetAsync(id);  
        }

        public async Task ImageItemAsync(IFormFile file, Product Product)
        {
           if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyToAsync(stream);

                Product.Photo = imageName;
                await _repository.CreateAsync(Product);
            }    
        }   
        public async Task UpdateItemAsync(IFormFile file, int id, Product Product)
        {
            var a = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{Product.Photo}");

            if (System.IO.File.Exists(a))
            {
                System.IO.File.Delete(a);
            }

            
            if (file == null)
            {
                Product.Photo = "NullPhoto.webp";
                await _repository.UpdateAsync(id, Product);
            }
            else
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ProductImages/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyToAsync(stream);

                Product.Photo = imageName;
                await _repository.UpdateAsync(id, Product);

            }




        }
    }
}
