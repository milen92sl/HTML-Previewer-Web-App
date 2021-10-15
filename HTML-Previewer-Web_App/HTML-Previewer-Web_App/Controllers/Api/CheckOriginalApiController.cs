namespace HTML_Previewer_Web_App.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using HTML_Previewer_Web_App.Models.Samples;
    using HTML_Previewer_Web_App.Services.Samples;

    [Route("api/checkOriginal")]
    [ApiController]
    public class CheckOriginalApiController : ControllerBase
    {
        private readonly ISamplesService samples;

        public CheckOriginalApiController(ISamplesService samples)
            => this.samples = samples;

        [HttpPost]
        public IActionResult Check(SampleApiModel sample)
        {
            var result = this.samples
                .CheckOriginal(sample.Id, sample.Code);

            return new JsonResult(result);
        }
    }
}
