using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreCodeFirstSample.Migrations;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/Attendence")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {

        private readonly IAttenedenceRepository _dataRepository;


        public AttendenceController(IAttenedenceRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Attendence> Get()
        {
            return _dataRepository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<Activity> GetActiveHours(int id)
        {
            var attendence = _dataRepository.GetLogsByEmployee(id);
            return attendence;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Attendence attendence)
        {
            if (attendence == null)
            {
                return BadRequest("Attendence is null.");
            }
            attendence.LogDate = DateTime.Now;
            _dataRepository.Add(attendence);
            return CreatedAtRoute(
                  "Get",
                  new { Id = attendence.ID },
                  attendence);
        }


    }
}
