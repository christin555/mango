using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Ticket
    {
        public int id { get; set; }

       [ForeignKey("clientId")]
       public int clientId { get; set; }
       // public ICollection<Service> Services { get; set; }
       //public Client Client { get; set; }
       public ICollection<TicketService> TicketService { get; set; }
    }
    public class TicketService
    {

        
        public int ticketId { get; set; }
       
        public int serviceId { get; set; }

        public Service Service { get; set; }
     
    }
}
