using Strona.Database;
using Strona.Entities;
using Strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _dbContext;

        public ClientService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(ClientModel client)
        {
            var entity = new ClientEntity
            {
                Name = client.Name,
                Mail = client.Mail,
                Topic = client.Topic,
                Description = client.Description
            };

            await _dbContext.Clients.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

    }
}
