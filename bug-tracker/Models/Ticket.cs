using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public class Ticket
    {
        public string TicketName { get; set; }
        public string TicketDescription { get; set; }
        public string TicketStatus { get; set; }
    }
}
