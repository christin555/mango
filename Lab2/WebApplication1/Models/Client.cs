using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Client
    {
      
        public int id { get; set; }
        public string FIO { get; set; }
        public string phone { get; set; } 
        public  ICollection<Ticket> Tickets { get; set; }
  
    }
}
