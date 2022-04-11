using System;
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

        [HttpGet("{id}")]
        public ActionResult<Trip> GetById(int id)
        {
            try
            {
                Trip trips = _ts.GetById(id);
                return Ok(trips);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Trip>> Create([FromBody] Trip tripData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                tripData.creatorId = userInfo.Id;
                Trip trip = _ts.Create(tripData);
                trip.Creator = userInfo;
                return Created($"api/trips/{trip.Id}", trip);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Remove(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_ts.Remove(id, userInfo));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Trip> Update(int id, [FromBody] Trip tripData)
        {
            try
            {
                tripData.Id = id;
                Trip trip = _ts.Update(tripData);
                return Ok(trip);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}