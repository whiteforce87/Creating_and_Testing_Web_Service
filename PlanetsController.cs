using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bau_api.Models;

namespace bau_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PlanetInfo> Get()
        {
            List<PlanetInfo> planets = DB.GetPlanet();
            return planets;
        }

        [HttpGet("{PlanetId}")]
        public PlanetInfo Get(int PlanetId)
        {
            List<PlanetInfo> planets = DB.GetPlanet();
            PlanetInfo planet = planets.Find(i=>i.PlanetId == PlanetId); 

            return planet;
        }
      
        [HttpPost]
        public string Post([FromBody] PlanetInfo planets)
        {
            return DB.AddPlanet(planets);
        }

        [HttpPost("{ParameterID}")]
        public string Post(int ParameterID, [FromBody] PlanetInfo planets)
        {
            return DB.AddPlanet(planets);
        }

        [HttpPut("{PlanetId}")]
        public string Put(int PlanetId, [FromBody] PlanetInfo planets)
        {
            return DB.UpdatePlanets(planets);
        }

        [HttpDelete("{PlanetId}")]
        public string Delete(int PlanetId)
        {
            return DB.DeletePlanet(PlanetId);
        }
    }
}
