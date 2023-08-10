using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIle_Json.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonFileController : ControllerBase
    {
        private readonly ILogicLayer _logicLayer;
        public JsonFileController(ILogicLayer logicLayer)
        {
            _logicLayer = logicLayer;
        }
        [HttpGet("FileReadToExcel")]
        public IActionResult GetJson()
        {
            var data = _logicLayer.GetJson();
            return Ok(data);
        }

    }
}
