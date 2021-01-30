using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public class Project
    {

        public int Id { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Please enter a name for your project")]
        public string ProjectName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter a description for your project")]
        public string ProjectDescription { get; set; }

        public Project()
        {

        }
    }
}
