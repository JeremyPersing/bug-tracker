using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using bug_tracker.Models;

namespace bug_tracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<bug_tracker.Models.Project> Project { get; set; }
        public DbSet<bug_tracker.Models.Ticket> Ticket { get; set; }
    }
}
