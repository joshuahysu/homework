using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using homework.Data;
using homework.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DappertestModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IConfiguration _configuration;
        private string _connectString;

        public DappertestModelsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DefaultConnection");
        }

        // GET: api/DappertestModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DappertestModel>>> GetDappertestModel()
        {
            return await _context.DappertestModel.ToListAsync();
        }

        // GET: api/DappertestModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DappertestModel>> GetDappertestModel(int id)
        {
            var dappertestModel = await _context.DappertestModel.FindAsync(id);

            if (dappertestModel == null)
            {
                return NotFound();
            }

            return dappertestModel;
        }

        // PUT: api/DappertestModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDappertestModel(int id, DappertestModel dappertestModel)
        {
            if (id != dappertestModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(dappertestModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DappertestModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DappertestModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DappertestModel>> PostDappertestModel(DappertestModel dappertestModel)
        {
            _context.DappertestModel.Add(dappertestModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDappertestModel", new { id = dappertestModel.Id }, dappertestModel);
        }

        // DELETE: api/DappertestModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DappertestModel>> DeleteDappertestModel(int id)
        {
            var dappertestModel = await _context.DappertestModel.FindAsync(id);
            if (dappertestModel == null)
            {
                return NotFound();
            }

            _context.DappertestModel.Remove(dappertestModel);
            await _context.SaveChangesAsync();

            return dappertestModel;
        }

        private bool DappertestModelExists(int id)
        {
            return _context.DappertestModel.Any(e => e.Id == id);
        }
    }
}
