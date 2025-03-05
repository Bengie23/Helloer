using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Platform.Challenge.Helloer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly Dictionary<string, string> Helloers = new Dictionary<string, string>()
        {
            {"MexDev", "Hola Mundo" },
            {"QuebecDev", "Bonjour le monde" },
            { "MontrealDev","Hello World" }
        };

        public HelloController(IConfiguration configuration)
        {
            this.config = configuration;
        }
        public ActionResult Index()
        {
            var role = GetDeveloperRole();
            return Ok(Helloers[role]);
        }

        private string GetDeveloperRole()
        {
            var value = this.config["DeveloperRole"];
            return value != null ? value : "Undefined";
        }
    }
}
