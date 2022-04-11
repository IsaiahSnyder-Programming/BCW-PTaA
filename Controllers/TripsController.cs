using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using PlanesTrainsandAutomobiles.Services;
using PlanesTrainsandAutomobiles.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlanesTrainsandAutomobiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly TripsService _ts;

        public TripsController(TripsService ts)
        {
            _ts = ts;
        }

        [HttpGet]
        public ActionResult<List<Trip>> GetAll()
        {
            try
            {
                List<Trip> trips = _ts.GetAll();
                return Ok(trips);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}