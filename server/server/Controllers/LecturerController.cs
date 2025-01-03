﻿using Microsoft.AspNetCore.Mvc;
using server.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        public static List<Lecturer> lecturers = new List<Lecturer> { 
            new Lecturer("Lecturer1","Lecturer1","Lecturer1@gmail.com","123456"),
            new Lecturer("Lecturer2","Lecturer2","Lecturer2@gmail.com","111111"),
            new Lecturer("Lecturer3","Lecturer3","Lecturer3@gmail.com","113311")
        };
        // GET: api/<LectureController>
        [HttpGet]
        public IEnumerable<Lecturer> Get()
        {
            return lecturers;
        }

        // GET api/<LectureController>/5
        [HttpGet("{id}")]
        public Lecturer Get(int id)
        {
            var lec=lecturers.Find(x => x.Id == id);
            if (lec != null)
                return lec;
            return null;
        }

        // POST api/<LectureController>
        [HttpPost]
        public void Post([FromBody] Lecturer value)
        {
            lecturers.Add(new Lecturer(value.UserName, value.Address, value.Email, value.Password));
        }

        // PUT api/<LectureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Lecturer value)
        {
            var lec=lecturers.Find(x=>x.Id == id);
            if(lec != null)
            {
                lec.Email = value.Email;
                lec.Address = value.Address;    
                lec.UserName= value.UserName;
                lec.Password= value.Password;
            }

        }

        // DELETE api/<LectureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var lec=lecturers.Find(x=> x.Id == id);
            if(lec != null)
                lecturers.Remove(lec);
        }
    }
}
