using JWT_Auth_Demo.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Auth_Demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        [HttpGet]
        public IActionResult Jwt()
        {
            return new ObjectResult(JwtToken.GenerateJwtToken());
        }
    }
}
