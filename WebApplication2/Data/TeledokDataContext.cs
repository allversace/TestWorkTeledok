using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class TeledokDataContext : DbContext
    {
        public TeledokDataContext(DbContextOptions<TeledokDataContext> options) : base(options) { }

        public DbSet<Client> Client { get; set; }

        public DbSet<Founder> Founder { get; set; }
    }
}
