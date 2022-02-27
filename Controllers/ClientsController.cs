using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Strona.Database;
using Strona.Entities;
using Strona.Models;
using Strona.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Controllers
{
    public class ClientsController : Controller
    {
        
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClientModel client)
        {
            await _clientService.Add(client);

            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> List(string name)
        {
            var clients = await _clientService.GetAllClients(name);
            return View(clients);
        }
    }
}
