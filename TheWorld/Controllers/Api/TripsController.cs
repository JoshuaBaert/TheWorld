using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_repository.GetAllTrips());
        }

        [HttpPost("")]
        public IActionResult Post ([FromBody]TripViewModel TheTrip)
        {
            if (ModelState.IsValid)
            {
                var newTrip = Mapper.Map<Trip> (TheTrip);

                return Created($"api/trips/{TheTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
            }

            return BadRequest ("Bad Data");
        }
    }
}
