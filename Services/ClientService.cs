using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ClientEntity>> GetAllClients(string name)
        {
            IQueryable<ClientEntity> clientQuery = _dbContext.Clients;

            if (!string.IsNullOrEmpty(name))
            {
                clientQuery = clientQuery.Where(x => x.Name.Contains(name));
            }

            var clients = await clientQuery.ToListAsync();
            return clients;
        }


    }
}
