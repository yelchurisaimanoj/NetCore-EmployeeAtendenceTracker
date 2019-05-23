using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFCoreCodeFirstSample.Entities;
using EFCoreCodeFirstSample.Migrations;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/Attendence")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {

        private readonly IDataRepository<Attendence> _dataRepository;
        private readonly IMapper _mapper;

        public AttendenceController(IDataRepository<Attendence> dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AttendenceViewModel> Get()
        {
            return _mapper.Map<IEnumerable<AttendenceViewModel>>(_dataRepository.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<Activity> GetActiveHours(int id)
        {
            //var attendence = _dataRepository.GetLogsByEmployee(id);
            var attendences = _dataRepository.GetListByID(id);

            var activities = attendences.GroupBy(x => x.LogDate.ToString("dd/M/yyyy")).Select(y =>
            {
                return new Activity { EmployeeID = y.FirstOrDefault().EmployeeID, LoginDateTime = y.Min().LogDate, LogOffDateTime = y.Max().LogDate, ActiveHours = (y.Max().LogDate - y.Min().LogDate).TotalHours };

            });
            return activities;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]AttendenceViewModel attendence)
        {
            if (attendence == null)
            {
                return BadRequest("Attendence is null.");
            }
            attendence.LogDate = DateTime.Now;
            _dataRepository.Add(_mapper.Map<Attendence>(attendence));
            return CreatedAtRoute(
                  "Get",
                  new { Id = attendence.ID },
                  attendence);
        }


    }
}
