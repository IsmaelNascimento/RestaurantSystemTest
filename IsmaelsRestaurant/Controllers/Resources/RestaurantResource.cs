using IsmaelsRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace IsmaelsRestaurant.Controllers.Resources
{
    public class RestaurantResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlateResource> Plates { get; set; }

        public RestaurantResource()
        {
            Plates = new Collection<PlateResource>();
        }
    }
}