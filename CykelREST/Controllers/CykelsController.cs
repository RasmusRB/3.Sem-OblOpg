using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CykelLib;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CykelREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CykelsController : ControllerBase
    {

        private static List<Cykel> _cykler = new List<Cykel>()
        {
            new Cykel(1, "blå", 1999.99, 16),
            new Cykel(2, "sort", 2999.99, 20),
            new Cykel(3, "grøn", 4999.99, 18),
            new Cykel(4, "grå", 9999.99, 32),
            new Cykel(5, "rød", 4599.99, 16)
        };

        // GET: api/<CykelsController>
        [HttpGet]
        public IEnumerable<Cykel> Get()
        {
            return _cykler;
        }

        // GET api/<CykelsController>/5
        [HttpGet]
        [Route("{id}")]
        public Cykel Get(int id)
        {
            return _cykler.Find(c => c.Id == id);
        }

        // POST api/<CykelsController>
        [HttpPost]
        public void Post([FromBody] Cykel value)
        {
            _cykler.Add(value);
        }

        // PUT api/<CykelsController>/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody] Cykel value)
        {
            Cykel cykel = Get(id);
            if (cykel != null)
            {
                cykel.Id = value.Id;
                cykel.Color = value.Color;
                cykel.Price = value.Price;
                cykel.Gear = value.Gear;
            }
        }

        // DELETE api/<CykelsController>/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            Cykel cykel = Get(id);
            _cykler.Remove(cykel);
        }
    }
}
