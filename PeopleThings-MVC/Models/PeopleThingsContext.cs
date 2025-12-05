using System.Data.Entity;

namespace PeopleThingsMVC.Models
{
    public class PeopleThingsContext : DbContext
    {
        
        public PeopleThingsContext() : base("PeopleThingsContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Things> Things { get; set; }
    }
}
