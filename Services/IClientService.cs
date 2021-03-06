using Strona.Entities;
using Strona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Services
{
    public interface IClientService
    {
        Task Add(ClientModel client);
        Task<IEnumerable<ClientEntity>> GetAllClients(string name);
        //Task AddAdmin();
    }
}
