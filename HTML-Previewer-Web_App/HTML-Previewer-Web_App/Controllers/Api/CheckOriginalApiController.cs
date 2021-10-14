using Microsoft.AspNetCore.Mvc;
using HTML_Previewer_Web_App.Models.Samples;
using HTML_Previewer_Web_App.Services.Samples;

namespace HTML_Previewer_Web_App.Controllers.Api
{
    [Route("api/checkOriginal")]
    [ApiController]
    public class CheckOriginalApiController : ControllerBase
    {
        private readonly ISamplesService _samples;

        public CheckOriginalApiController(ISamplesService samples)
            => this._samples = samples;

        [HttpPost]
        public IActionResult Check(SampleApiModel sample)
        {
            var result = this._samples
                .CheckOriginal(sample.Id, sample.Code);

            return new JsonResult(result);
        }
    }
}
