using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }
        [Required(AllowEmptyStrings = false)]
        public CuisineType Cuisine { get; set; }

        [StringLength(50)]
        public string HeadChef { get; set; }

    }
}
