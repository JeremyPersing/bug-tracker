using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bug_tracker.Models
{
    public class CreateRoleModel
    {
        [Required]
        [Display(Name = "Roll")]
        public string RoleName { get; set; }
    }
}
