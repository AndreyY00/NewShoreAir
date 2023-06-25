using DB;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewShoreAir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private NewShoreAirContext _context;
        public ContratoController(NewShoreAirContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Transport> Get() => _context.Transportes.ToList();

    }
}
