using LavenderHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavenderHome.Business.Abstract
{
   public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllItemsAsync();
        Task<Contact> GetItemByIdAsync(int id);
        Task<int> CreateItemAsync(Contact newProduct);
        Task DeleteItemAsync(Contact Product);
       
    }
}
