using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IsmaelsRestaurant.Models
{
    [Table("Plates")]
    public class Plate
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant;

        public Plate()
        {
            Restaurant = new Restaurant();
        }
    }
}