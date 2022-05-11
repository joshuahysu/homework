using Dapper;
using homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>

        private readonly IConfiguration _configuration;
        private string _connectString;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IEnumerable<DappertestModel> Get()        
        {

            _connectString = _configuration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(_connectString))
            {
                return conn.Query<DappertestModel>("SELECT * FROM Dappertest");
            }

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
