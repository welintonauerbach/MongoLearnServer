using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoLearnServer.Model;
using MongoLearnServer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoLearnServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly PartsService _partsService;

        public PartsController(PartsService partsService)
        {
            _partsService = partsService;
        }

        // GET: api/<PartsController>
        [HttpGet]
        public ActionResult<List<PartModel>> Get()
        {
            return _partsService.Get();
        }

        // GET api/<PartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartsController>
        [HttpPost]
        public PartModel CreatePart(PartModel partModel)
        {
            //var part = new PartModel();
            //part.Name = "522222";
            //part.Description = "Encaixe Principal";
            //part.StockNumber = "254777";

            _partsService.Create(partModel);

            return partModel;
        }

        // PUT api/<PartsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PartsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
