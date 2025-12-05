using System.Collections.Generic;
using System.Data.Entity;

namespace PeopleThingsMVC.Models
{
    /// <summary>
    /// Seeds the Catch Keeper demo database with sample Anglers (People)
    /// and their associated Gear (Things).
    /// </summary>
    public class PeopleThingsInitializer : DropCreateDatabaseIfModelChanges<PeopleThingsContext>
    {
        protected override void Seed(PeopleThingsContext context)
        {
            // --- Seed People (Anglers) ---
            var people = new List<Person>
            {
                new Person { PersonName = "Branden Maxwell", City = "Atwood Lake",     Email = "maxy@catchkeeper.com",   Age = 10 },
                new Person { PersonName = "Molly Rivers",     City = "Mosquito Creek", Email = "molly@catchkeeper.com",  Age = 5 },
                new Person { PersonName = "Sasquatch Sam",    City = "Leesville Lake", Email = "squatch@catchkeeper.com",Age = 20 },
                new Person { PersonName = "River Ray",        City = "Tappan Lake",    Email = "ray@catchkeeper.com",    Age = 15 },
                new Person { PersonName = "Dockside Dan",     City = "Atwood Lake",    Email = "dan@catchkeeper.com",    Age = 8 },
                new Person { PersonName = "Buddy the Bass",   City = "Minnow Pond",    Email = "buddy@catchkeeper.com",  Age = 3 },
                new Person { PersonName = "Kayak Kelly",      City = "Nimisila",       Email = "kelly@catchkeeper.com",  Age = 6 },
                new Person { PersonName = "Largie Luke",      City = "Dover Dam",      Email = "luke@catchkeeper.com",   Age = 4 },
                new Person { PersonName = "Crankbait Chris",  City = "Atwood Lake",    Email = "chris@catchkeeper.com",  Age = 12 },
                new Person { PersonName = "Spinnerbait Sue",  City = "Portage Lakes",  Email = "sue@catchkeeper.com",    Age = 9 },
                new Person { PersonName = "Topwater Tom",     City = "Mosquito Creek", Email = "tom@catchkeeper.com",    Age = 14 }
            };

            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();

            // --- Seed Things (Gear) ---
            var things = new List<Things>
            {
                new Things { ThingName = "St. Croix Bass X Rod",       Category = "Rod",        Notes = "7' MH Fast – jig setup",             PersonId = 1 },
                new Things { ThingName = "Shimano SLX Reel",           Category = "Reel",       Notes = "15lb fluoro",                        PersonId = 1 },
                new Things { ThingName = "Green Pumpkin Senko",        Category = "Lure",       Notes = "Weightless – dock skipping",         PersonId = 2 },
                new Things { ThingName = "Chartreuse Spinnerbait",     Category = "Lure",       Notes = "Windy banks, stained water",         PersonId = 3 },
                new Things { ThingName = "Black Buzzbait",             Category = "Lure",       Notes = "Low light, frog bite",               PersonId = 4 },
                new Things { ThingName = "Plano 3700 Box",             Category = "Tackle Box", Notes = "Topwater box",                        PersonId = 5 },
                new Things { ThingName = "Kayak Crate",                Category = "Storage",    Notes = "Custom milk crate organizer",        PersonId = 7 },
                new Things { ThingName = "Scale & Bump Board",         Category = "Tools",      Notes = "Tournament legal measurements",      PersonId = 1 },
                new Things { ThingName = "Chartreuse/White Chatterbait",Category = "Lure",      Notes = "Grass edges at Atwood",              PersonId = 1 },
                new Things { ThingName = "GoPro Chest Mount",          Category = "Electronics",Notes = "For Catch Keeper clips",             PersonId = 8 },
                new Things { ThingName = "Rain Suit",                  Category = "Apparel",    Notes = "Cold front survival",                PersonId = 9 },
                new Things { ThingName = "Minnow Bucket",              Category = "Accessory",  Notes = "Community server mascot",            PersonId = 6 }
            };

            things.ForEach(t => context.Things.Add(t));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
