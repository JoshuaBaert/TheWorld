using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;

        public WorldContextSeedData (WorldContext context)
        {
            _context = context
        }

        public async Task EnsureSeeData ()
        {
            if (!_context.Trips.Any ())
            {
                var usTrip = new Trip ()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = "US Trip",
                    UserName = "", //TODO Add UserName
                    Stops = new List<Stop> ()
                    {

                    }
                };

                _context.Trips.Add (usTrip);

                _context.Stops.AddRange(usTrip.Stops);

                var worldTrip = new Trip()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = "World Trip",
                    UserName = "", //TODO Add UserName
                    Stops = new List<Stop>()
                    {

                    }
                };

                _context.Trips.Add(worldTrip);

                _context.Stops.AddRange(worldTrip.Stops);
            }
        }
    }
}
