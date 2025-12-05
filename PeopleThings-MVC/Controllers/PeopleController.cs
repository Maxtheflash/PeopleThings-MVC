using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PeopleThingsMVC.Models;

namespace PeopleThingsMVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleThingsContext db = new PeopleThingsContext();

        // GET: People
        // Includes: sorting, filtering by name, and simple paging
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // For remembering current sort and filter in the view
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";
            ViewBag.AgeSortParm = sortOrder == "Age" ? "age_desc" : "Age";

            // If user typed a new search, reset page to 1
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            // Base query
            var people = db.People.AsQueryable();

            // FILTER: by PersonName (PeopleName) if searchString provided
            if (!string.IsNullOrEmpty(searchString))
            {
                people = people.Where(p => p.PersonName.Contains(searchString));
            }

            // SORT
            switch (sortOrder)
            {
                case "name_desc":
                    people = people.OrderByDescending(p => p.PersonName);
                    break;
                case "City":
                    people = people.OrderBy(p => p.City);
                    break;
                case "city_desc":
                    people = people.OrderByDescending(p => p.City);
                    break;
                case "Age":
                    people = people.OrderBy(p => p.Age);
                    break;
                case "age_desc":
                    people = people.OrderByDescending(p => p.Age);
                    break;
                default:
                    people = people.OrderBy(p => p.PersonName);
                    break;
            }

            // PAGING
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            int totalItems = people.Count();
            people = people.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.HasPreviousPage = (pageNumber > 1);
            ViewBag.HasNextPage = (pageNumber * pageSize < totalItems);

            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Eager-load Things so the Details view can show all their gear/items
            var person = db.People
                           .Include(p => p.Things)
                           .SingleOrDefault(p => p.PersonId == id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,PersonName,City,Email,Age")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,PersonName,City,Email,Age")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            if (person != null)
            {
                db.People.Remove(person);
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
