using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ServiceContext: DbContext
    {
        public ServiceContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TicketService>()
        .HasKey(c => new { c.ticketId, c.serviceId });
            base.OnModelCreating(builder);

        }

      public DbSet<Client> Clients { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    
        public DbSet<Service> Services { get; set; } 
         public DbSet<TicketService> TicketService { get; set; }
    }
}
