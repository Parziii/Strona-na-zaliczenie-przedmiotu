using Microsoft.EntityFrameworkCore;
using Strona.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Strona.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
    }
}
