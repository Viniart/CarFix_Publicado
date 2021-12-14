using CarFix.Project.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarFix.Project.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerVisionController : ControllerBase
    {
        private TextRecognition _reconhecimentoPlaca = new TextRecognition();
        
        [HttpPost()]
        public IActionResult ReadPlate(string url)
        {
            return StatusCode(200, _reconhecimentoPlaca.ReadFile(url));
        }
    }
}
