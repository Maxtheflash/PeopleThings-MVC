using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleThingsMVC.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [Display(Name = "Angler Name")]
        public string PersonName { get; set; }

        [Display(Name = "Home Lake")]
        public string City { get; set; }

        [Display(Name = "Contact Email")]
        public string Email { get; set; }

        [Display(Name = "Years Fishing")]
        public int Age { get; set; }

        // navigation to Things
        public virtual ICollection<Things> Things { get; set; }
    }
}
