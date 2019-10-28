using AutoMapper;
using IsmaelsRestaurant.Controllers.Resources;
using IsmaelsRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsmaelsRestaurant.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Plate, PlateResource>();
            CreateMap<Restaurant, RestaurantResource>();
        }
    }
}