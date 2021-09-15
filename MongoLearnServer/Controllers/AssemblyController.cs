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
    public class AssemblyController : ControllerBase
    {
        private readonly AssemblyService _assService;
        //private readonly AssemblyService _partService;

        public AssemblyController(AssemblyService AssemblyService)
        {
            _assService = AssemblyService;
        }

        // GET: api/<PartsController>
        [HttpGet]
        public ActionResult<List<AssemblyModel>> Get()
        {
            return _assService.Get();
        }

        // GET api/<PartsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartsController>
        [HttpPost]
        public AssemblyModel CreatePart(AssemblyModel assemblyModel)
        {
            var part = new PartModel();
            part.Name = "522222";
            part.Description = "Encaixe Principal";
            part.StockNumber = "254777";

            assemblyModel.PartsList.Add(part);

            _assService.Create(assemblyModel);

            return assemblyModel;
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
