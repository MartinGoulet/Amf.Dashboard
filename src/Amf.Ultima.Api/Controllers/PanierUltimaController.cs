using Amf.Ultima.Api.DataStorage;
using Amf.Ultima.Api.HubConfig;
using Amf.Ultima.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Amf.Ultima.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanierUltimaController : ControllerBase
    {
        private IHubContext<UltimaHub> _hub;

        public PanierUltimaController(IHubContext<UltimaHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            return Ok(new { Message = "Request Completed" });
        }
    }
}