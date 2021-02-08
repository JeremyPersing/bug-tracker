using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public class ProjectsWithTicketsModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }

        public List<TicketModel> Tickets { get; set; }

    }
}
