using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Api
{
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private IWorldRepository _repository;

        public TripsController (IWorldRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get ()
        {
            var results = _repository.GetAllTrips ();

            return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel TheTrip)
        {
            if (!ModelState.IsValid) return BadRequest ("Bad Data");

            var newTrip = Mapper.Map<Trip> (TheTrip);
            _repository.AddTrip(newTrip);

            if (await _repository.SaveChangesAsync ())
            {
                return Created ($"api/trips/{TheTrip.Name}", Mapper.Map<TripViewModel> (newTrip));
            }
            else
            {
                return BadRequest ("Failed to save changes to database.");
            }
        }
    }
}
