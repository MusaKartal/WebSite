using AutoMapper;
using LavenderHome.Business.Abstract;
using LavenderHome.Infrastructure;
using LavenderHome.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavenderHome.Business.Services
{
    public class HomeManeger : IContactService
    {
        protected readonly IGenericRepository<Contact> _repository;
        private readonly IMapper mapper;
        private readonly ILogger<HomeManeger> logger;
        public HomeManeger(IGenericRepository<Contact> repository, IMapper _mapper, ILogger<HomeManeger> _logger)
        {
            _repository = repository;
            mapper = _mapper;
            logger = _logger;
        }
        public async Task<int> CreateItemAsync(Contact newContact)
        {
            try
            {
                var user = mapper.Map<Contact>(newContact);
                await _repository.CreateAsync(user);
                return user.Id;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Exception Error During Add User", newContact);
                throw e;
            }
        }

        public async Task DeleteItemAsync(Contact contact)
        {
            await _repository.DeleteAsync(contact.Id);
        }

        public async Task<IEnumerable<Contact>> GetAllItemsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Contact> GetItemByIdAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
