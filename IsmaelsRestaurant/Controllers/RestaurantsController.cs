using AutoMapper;
using IsmaelsRestaurant.Controllers.Resources;
using IsmaelsRestaurant.Models;
using IsmaelsRestaurant.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsmaelsRestaurant.Controllers
{
    [Route("/api/restaurants")]
    public class RestaurantsController : Controller
    {
        private readonly IsmaelsRestaurantDbContext context;
        private readonly IMapper mapper;

        public RestaurantsController(IsmaelsRestaurantDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/restaurants/search/{search}")]
        public async Task<IActionResult> GetRestaurants(string search)
        {
            var restaurants = await context.Restaurants.Where(res => res.Name.Contains(search)).ToListAsync();

            try
            {
                return Ok(restaurants);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var restaurant = await context.Restaurants.FindAsync(id);

            try
            {
                return Ok(restaurant);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await context.Restaurants.ToListAsync();

            try
            {
                return Ok(restaurants);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveRestaurant([FromBody] Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                context.Restaurants.Add(restaurant);
                await context.SaveChangesAsync();
                return Ok(restaurant);
            }
            catch(Exception ex)
            {
                return BadRequest("Error:: " + ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] Restaurant restaurantNew)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                var restaurantOld = await context.Restaurants.FindAsync(id);

                if (restaurantOld == null)
                {
                    return NotFound();
                }

                restaurantOld.Name = restaurantNew.Name;
                context.Restaurants.Update(restaurantOld);
                context.SaveChanges();

                return Ok(restaurantOld);
            }
            catch (Exception ex)
            {
                return BadRequest("Error:: " + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                var restaurant = await context.Restaurants.FindAsync(id);

                if (restaurant == null)
                {
                    return NotFound();
                }

                context.Restaurants.Remove(restaurant);
                context.SaveChanges();

                return Ok("Count Total:: " + context.Restaurants.Count());
            }
            catch (Exception ex)
            {
                return BadRequest("Error:: " + ex);
            }
        }
    }
}