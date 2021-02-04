using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public class ProjectWithTicketsModel
    {
        public ProjectModel Project { get; set; }
        public TicketModel Tickets { get; set; }
}
}
