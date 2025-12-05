using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PeopleThingsMVC.Models;

namespace PeopleThingsMVC.Controllers
{
    public class ThingsController : Controller
    {
        private readonly PeopleThingsContext db = new PeopleThingsContext();

        // GET: Things
        // Show all gear/things, including which Person/Angler owns them
        public ActionResult Index()
        {
            var things = db.Things
                           .Include(t => t.Person)   // eager-load Person for display
                           .OrderBy(t => t.ThingName);

            return View(things.ToList());
        }

        // GET: Things/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Eager-load Person so the view can use Model.Person.PersonName
            var things = db.Things
                           .Include(t => t.Person)
                           .SingleOrDefault(t => t.ThingsId == id);

            if (things == null)
            {
                return HttpNotFound();
            }

            return View(things);
        }

        // GET: Things/Create
        public ActionResult Create()
        {
            // Dropdown list of People/Anglers
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "PersonName");
            return View();
        }

        // POST: Things/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThingsId,ThingName,Category,Notes,PersonId")] Things things)
        {
            if (ModelState.IsValid)
            {
                db.Things.Add(things);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "PersonName", things.PersonId);
            return View(things);
        }

        // GET: Things/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var things = db.Things.Find(id);
            if (things == null)
            {
                return HttpNotFound();
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "PersonName", things.PersonId);
            return View(things);
        }

        // POST: Things/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThingsId,ThingName,Category,Notes,PersonId")] Things things)
        {
            if (ModelState.IsValid)
            {
                db.Entry(things).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "PersonName", things.PersonId);
            return View(things);
        }

        // GET: Things/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var things = db.Things.Find(id);
            if (things == null)
            {
                return HttpNotFound();
            }

            return View(things);
        }

        // POST: Things/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var things = db.Things.Find(id);
            if (things != null)
            {
                db.Things.Remove(things);
                db.SaveChanges();
            }

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
