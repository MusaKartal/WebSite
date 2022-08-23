using LavenderHome.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavenderHome.Business.Abstract
{
    public interface IService
    {
        Task<IEnumerable<Product>> GetAllItemsAsync();
        Task<Product> GetItemByIdAsync(int id);
        Task<int> CreateItemAsync(Product newProduct);
        Task UpdateItemAsync(IFormFile file, int id, Product Product);
        Task DeleteItemAsync(Product Product);
        Task ImageItemAsync(IFormFile file, Product Product);


   
    }
}
