using Microsoft.EntityFrameworkCore;
using WebAPITest.EBbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly ZealandIdDbContext _dbContext;

        public SensorController(ZealandIdDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Sensors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensorer()
        {
            if (_dbContext.Sensorer == null)
            {
                return NotFound();
            }
            return await _dbContext.Sensorer.ToListAsync();
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            if (_dbContext.Sensorer == null)
            {
                return NotFound("DbContext can'be null");
            }
            var sensor = await _dbContext.Sensorer.FindAsync(id);

            if (sensor == null)
            {
                return NotFound("No Such sensor exists");
            }
            return Ok(sensor);
        }

        // POST: api/Sensors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

    }
}