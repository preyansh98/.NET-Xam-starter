using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProfilesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
    }
}
