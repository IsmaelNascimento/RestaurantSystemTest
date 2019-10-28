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
    [Route("/api/plates")]
    public class PlatesController : Controller
    {
        private readonly IsmaelsRestaurantDbContext context;
        private readonly IMapper mapper;

        public PlatesController(IsmaelsRestaurantDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/plates/search/{search}")]
        public async Task<IActionResult> GetRestaurants(string search)
        {
            var plates = await context.Plates.Where(plate => plate.Name.Contains(search)).ToListAsync();

            try
            {
                return Ok(plates);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetPlates()
        {
            var restaurants = await context.Restaurants.ToListAsync();
            var platesAux = await context.Plates.ToListAsync();
            List<Plate> plates = new List<Plate>();

            foreach (var plate in platesAux)
            {
                foreach (var restaurant in restaurants)
                {
                    if(plate.RestaurantId == restaurant.Id)
                    {
                        plate.Restaurant.Id = restaurant.Id;
                        plate.Restaurant.Name = restaurant.Name;
                        plates.Add(plate);
                        continue;
                    }
                }
            }

            //var plates = await context.Plates.ToListAsync();

            try
            {
                return Ok(plates);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SavePlate([FromBody] Plate plate)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                context.Plates.Add(plate);
                await context.SaveChangesAsync();
                return Ok(plate);
            }
            catch (Exception ex)
            {
                return BadRequest("Error:: " + ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlate(int id, [FromBody] Plate plateNew)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                var plateOld = await context.Plates.FindAsync(id);

                if (plateOld == null)
                {
                    return NotFound();
                }

                plateOld.Name = plateNew.Name;
                plateOld.Price = plateNew.Price;
                plateOld.RestaurantId = plateNew.RestaurantId;

                context.Plates.Update(plateOld);
                context.SaveChanges();

                return Ok(plateOld);
            }
            catch (Exception ex)
            {
                return BadRequest("Error:: " + ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlate(int id)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {
                var plate = await context.Plates.FindAsync(id);

                if (plate == null)
                {
                    return NotFound();
                }

                context.Plates.Remove(plate);
                context.SaveChanges();

                return Ok("Count Total:: " + context.Plates.Count());
            }
            catch (Exception ex)
            {
                return BadRequest("Error:: " + ex);
            }
        }
    }
}