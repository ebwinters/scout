using Microsoft.AspNetCore.Mvc;
using scout.Controllers.Middleware;
using Scout.Infrastructure;

namespace scout.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoutController : ControllerBase
    {
        private readonly ILogger<ScoutController> _logger;
        private readonly ScoutRepository _scoutRepository;

        public ScoutController(ILogger<ScoutController> logger, ScoutRepository scoutRepository)
        {
            _logger = logger;
            _scoutRepository = scoutRepository;
        }

        [HttpGet("GetScouts")]
        [BasicAuth]
        public async Task<IEnumerable<ScoutDbo>> Get()
        {
            return await _scoutRepository.getScouts();
        }

        [HttpPost("CreateScout")]
        [BasicAuth]
        public async Task<ActionResult> CreateScout([FromBody] ScoutDbo scout)
        {
            await _scoutRepository.createScout(scout);
            return Ok();
        }
    }
}