﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public class TicketModel
    {
        public int Id { get; set; }

        [Display(Name = "Ticket Name")]
        [Required(ErrorMessage = "Please enter a name for your ticket")]
        public string TicketName { get; set; }

        [Display(Name = "Ticket Description")]
        [Required(ErrorMessage = "Please enter a description for your ticket")]
        public string TicketDescription { get; set; }

        [Display(Name = "Ticket Status")]
        [Required(ErrorMessage = "Please select a status for your ticket")]
        public string TicketStatus { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please select a start date for your ticket")]
        public string StartDate { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Please select Project for your ticket")]
        public string TicketProjectName { get; set; }

        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        public TicketModel()
        {

        }
    }
}
