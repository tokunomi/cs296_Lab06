using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TSTOneighboreenos.DAL;
using TSTOneighboreenos.Models;

namespace TSTOneighboreenos.Controllers
{
    public class NeighborController : Controller
    {
        private NeighboreenoContext db = new NeighboreenoContext();
        // GET: Neighbor
        public ActionResult Index()
        {
            return View(db.Neighbors.ToList());
        }

        /* TO BE ADDED LATER
        // GET: Neighbor Detail
        public ActionResult Details()
        {
            // Add something?

            return View();
        }
         */

        // GET: Neighbor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Neighbor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        // NOTE: Adjusted for Lab 5 to add a form to add a new player: Added a try-catch block
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TSTOhandle,Lv")] Neighbor neighbor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Neighbors.Add(neighbor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(neighbor);
        }

    }
}