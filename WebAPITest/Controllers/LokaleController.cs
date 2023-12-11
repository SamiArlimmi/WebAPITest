using Microsoft.EntityFrameworkCore;
using WebAPITest.EBbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LokaleController : ControllerBase
    {
        private readonly ZealandIdDbContext _dbContext;

        public LokaleController(ZealandIdDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Lokale
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lokale>>> GetLokaler()
        {
            if (_dbContext.lokaler == null)
            {
                return NotFound();
            }
            return await _dbContext.lokaler.ToListAsync();
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<Lokale>> GetLokale(int id)
        {
            if (_dbContext.lokaler == null)
            {
                return NotFound("DbContext can'be null");
            }
            var lokale = await _dbContext.lokaler.FindAsync(id);

            if (lokale == null)
            {
                return NotFound("No Such lokale exists");
            }
            return Ok(lokale);
        }

    }
}