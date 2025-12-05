using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleThingsMVC.Models
{
    public class Things
    {
        //PRIMARY KEY – EF will use this
        public int ThingsId { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string ThingName { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        // Foreign key to Person
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}
