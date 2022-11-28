using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Scout.Api.Controllers.Middleware;
using Scout.Infrastructure.Contexts;
using Scout.Infrastructure.Entities;

namespace scout.Controllers
{
    [ApiController]
    [Route("odata")]
    public class ScoutController : ODataController
    {
        private readonly ILogger<ScoutController> _logger;
        private readonly ScoutContext _context;

        public ScoutController(ILogger<ScoutController> logger, ScoutContext context)
        {
            _logger = logger;
            _context = context;
        }

        [EnableQuery]
        [HttpGet("Scouts")]
        [BasicAuth]
        public IActionResult GetScouts()
        {
            return Ok(_context.Scouts);
        }

        [HttpPost("CreateScout")]
        [BasicAuth]
        public async Task<ActionResult> CreateScout([FromBody] ScoutEntity scout)
        {
            _context.Scouts.Add(scout);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}