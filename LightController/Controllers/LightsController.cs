using LightController.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Drawing;

namespace LightController.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LightsController : ControllerBase
    {

        private readonly ILogger<LightsController> _logger;

        public LightsController(ILogger<LightsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Sets the status of the light
        /// </summary>
        /// <param name="id">The id of the light you want to set</param>
        /// <param name="state">Whether you want to turn the light on or off</param>
        /// <param name="hexColor">The color code that you want to set to the light</param>
        /// <returns>Return message Success when the call finishes</returns>
        [HttpGet(Name = "SetLight")]
        [ActionName("SetLight")]
        public IActionResult SetLight(int id, bool state, string hexColor)
        {
            _logger.LogInformation("SetLight {0}, state {1}, color {2}", id, state, hexColor);

            Color color = System.Drawing.ColorTranslator.FromHtml(hexColor);

            var ls = new LightStatus();
            ls.setLight(id, (state? color.R : (byte)0), (state ? color.G : (byte)0), (state ? color.B : (byte)0));

            return new JsonResult("Success");
        }

        /// <summary>
        /// Gets the status of the light
        /// </summary>
        /// <param name="id">The id of the light you want to check status of</param>
        /// <returns>Boolean whether light is on or off, true is on and false is off</returns>
        [HttpGet(Name = "GetLight")]
        [ActionName("GetLight")]
        public IActionResult GetLight(int id)
        {
            _logger.LogInformation("GetLight {0}", id);

            var ls = new LightStatus();
            var ret = new Hashtable();
            ret.Add("status", ls.getLight(id));
            return new JsonResult(ret);
        }
    }
}