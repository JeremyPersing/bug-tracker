using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bug_tracker.Data;
using bug_tracker.Models;
using Microsoft.AspNetCore.Authorization;
using PagedList;

namespace bug_tracker.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Tickets
        [Authorize]
        public async Task<ViewResult> Index(
            string sortOrder,
            string searchString,
            string currentFilter,
            int? pageNumber)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tickets = from t in _context.Ticket select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(t => t.TicketName.Contains(searchString)
                                        || t.TicketProjectName.Contains(searchString)
                                        || t.TicketDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    tickets = tickets.OrderByDescending(t => t.TicketProjectName);
                    break;
                case "Status":
                    tickets = tickets.OrderBy(t => t.TicketStatus);
                    break;
                case "status_desc":
                    tickets = tickets.OrderByDescending(t => t.TicketStatus);
                    break;
                case "Date":
                    tickets = tickets.OrderBy(t => t.StartDate);
                    break;
                case "date_desc":
                    tickets = tickets.OrderByDescending(t => t.StartDate);
                    break;
                default:
                    tickets = tickets.OrderBy(t => t.TicketProjectName);
                    break;
            }

            int pageSize = 5;

            return View(await PaginatedList<TicketModel>.CreateAsync(tickets.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Tickets/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["TicketProjectName"] = new SelectList(_context.Project, "ProjectName", "ProjectName", "ProjectDescription");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketName,TicketDescription,TicketStatus,StartDate,EndDate,TicketProjectName")] TicketModel ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketProjectName"] = new SelectList(_context.Project, "ProjectName", "ProjectName", "ProjectDescription", ticket.TicketProjectName);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketName,TicketDescription,TicketStatus,StartDate,EndDate,TicketProjectName")] TicketModel ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["TicketProjectName"] = new SelectList(_context.Project, "Id", "ProjectName", "ProjectDescription", ticket.TicketProjectName);
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            ViewData["TicketProjectName"] = new SelectList(_context.Project, "Id", "ProjectName", "ProjectDescription", ticket.TicketProjectName);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
