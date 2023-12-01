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
        [HttpGet("JsonToExcelFile")]
        public IActionResult JsonTOEXcel()
        {
            var data = _logicLayer.JsonTOEXcel();
            return Ok(data);
        }

        [HttpGet("ExcelToJsonFile")]
        public IActionResult ExcelToJson()
        {
            var data2  = _logicLayer.ExcelToJson();
            return Ok(data2);
        }

    }
}
