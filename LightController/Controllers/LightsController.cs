using LightController.Data;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace LightController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LightsController : ControllerBase
    {

        private readonly ILogger<LightsController> _logger;

        public LightsController(ILogger<LightsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "SetLights")]
        public String SetLight(int id, bool state, string hexColor)
        {
            Color color = System.Drawing.ColorTranslator.FromHtml(hexColor);

            var ls = new LightStatus();
            ls.setLight(id, (state? color.R : (byte)0), (state ? color.G : (byte)0), (state ? color.B : (byte)0));

            return "Success";
        }
    }
}