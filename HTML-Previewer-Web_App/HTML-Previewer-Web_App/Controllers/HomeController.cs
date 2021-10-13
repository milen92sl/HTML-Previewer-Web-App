namespace HTML_Previewer_Web_App.Controllers
{
    using HTML_Previewer_Web_App.Models;
    using HTML_Previewer_Web_App.Models.Samples;
    using HTML_Previewer_Web_App.Services.Samples;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ISamplesService samples;

        public HomeController(ISamplesService samples)
            => this.samples = samples;

        public IActionResult Index(string id)
        {
            var sample = this.samples.SampleCode(id);

            if (sample != null)
            {
                return View(new SampleFormModel { Id = id, Code = sample.Code });
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
