using Microsoft.AspNetCore.Mvc;
using Strona.Database;
using Strona.Entities;
using Strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Controllers
{
    public class ClientsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ClientsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClientModel client)
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

            return View();
        }
    }
}
