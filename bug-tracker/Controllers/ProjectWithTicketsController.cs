using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bug_tracker.Data;
using bug_tracker.Models;


namespace bug_tracker.Controllers
{
    public class ProjectWithTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ProjectWithTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectWithTicketsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectWithTicketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectWithTicketsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectWithTicketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectWithTicketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectWithTicketsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectWithTicketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectWithTicketsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
