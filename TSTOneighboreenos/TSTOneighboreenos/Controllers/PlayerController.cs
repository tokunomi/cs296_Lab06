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
    public class PlayerController : Controller
    {
        private NeighboreenoContext db = new NeighboreenoContext();

        // GET: Player
        public ActionResult Index()
        {
            return View(db.Players.ToList());
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            // Adding a selection list of Neighbors to choose from
            var neighbors = new List<string>();
            var neighborsQuery = from n in db.Neighbors
                                 orderby n.TSTOhandle
                                 select n.TSTOhandle;

            neighbors.AddRange(neighborsQuery);
            ViewBag.neighborsList = new SelectList(neighbors);

            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        // NOTE:  Added a try-catch block
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TSTOhandle,Level,NameFirst,MidInit,NameLast,Email,SpringfieldPath,Active,AddMe")] Player player, string neighbor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // add a Neighbor using Neighbor entity, if it allows me to
                    //Neighbor friend = new Neighbor();
                    var aNeighbor = (from n in db.Neighbors
                                         where n.TSTOhandle == neighbor
                                         select n).FirstOrDefault<Neighbor>();
                    player.ID = aNeighbor.ID;
                    db.Neighbors.Add(aNeighbor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                /*if (ModelState.IsValid)
                {
                    // add a Neighbor using Friend entity
                    Friend friend = new Friend();
                    var aNeighbor = (from n in db.Neighbors
                                     where n.TSTOhandle == neighbor
                                     select n).FirstOrDefault<Neighbor>();
                    friend.NeighborID = aNeighbor.ID;  // error around here; looking for a null(?)
  
                    db.Players.Add(player);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }  */

                
                // original code
                if (ModelState.IsValid)
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }  
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        // NOTE: Removed ID field and added MidInit to Bind
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var playerToUpdate = db.Players.Find(id);
            if(TryUpdateModel(playerToUpdate, "",
                new string[] { "TSTOhandle", "Level", "NameFirst", "MidInt", "NameLast", "Email"}))
            {
                try
                {
                    db.Entry(playerToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(playerToUpdate);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
