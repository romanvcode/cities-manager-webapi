﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitiesManager.Infrastructure.DatabaseContext;
using Asp.Versioning;

namespace CitiesManager.WebAPI.Controllers.v2
{
    [ApiVersion(2)]
    public class CitiesController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        /// <summary>
        /// To get all cities (only city name) from the 'cities' table.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetCities()
        {
            var cities = await _context.Cities
                .OrderBy(c => c.CityName)
                .Select(c => c.CityName)
                .ToListAsync();
            return cities;
        }
    }
}
