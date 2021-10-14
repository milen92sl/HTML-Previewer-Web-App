namespace HTML_Previewer_Web_App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using HTML_Previewer_Web_App.Infrastructure;
    using HTML_Previewer_Web_App.Models.Samples;
    using HTML_Previewer_Web_App.Services.Samples;
    using Microsoft.AspNetCore.Authorization;
    using HTML_Previewer_Web_App.Services.Conversions;

    using static HTML_Previewer_Web_App.DataWebConstants;

    public class SamplesController : Controller
    {
        private const int MaxCodeSizeInMb = 5;

        private readonly ISamplesService samples;
        private readonly IConvert convert;

        public SamplesController(
            ISamplesService samples,
            IConvert convert)
        {
            this.samples = samples;
            this.convert = convert;
        }

        [Authorize]
        public IActionResult All()
        {
            var samples = this.samples
                .All(User.Id());

            return View(samples);
        }

        [Authorize]
        [HttpPost] 
        public IActionResult Save(SampleFormModel sample)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessageKey] = InvalidSampleContent;
                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            var size = this.convert
                .ConvertBytesToMegabytes(sample.Code);

            if (size > MaxCodeSizeInMb)
            {
                TempData[ErrorMessageKey] = InvalidSampleSize;
                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            this.samples
                .Save(sample.Code, User.Id());

            TempData[SuccessMessageKey] = SuccessfulSavedSample;

            return RedirectToAction("All", "Samples", new { area = string.Empty });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(SampleFormModel sample)
        {
            var isExist = this.samples
                .IsSampleExist(sample.Id, User.Id());

            if (!isExist)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessageKey] = InvalidSampleContent;

                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            var size = this.convert
                .ConvertBytesToMegabytes(sample.Code);

            if (size > MaxCodeSizeInMb)
            {
                TempData[ErrorMessageKey] = InvalidSampleSize;
                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            this.samples
                .Edit(sample.Id, sample.Code, User.Id());

            TempData[SuccessMessageKey] = SuccessfulEditSample;

            return RedirectToAction("All", "Samples", new { area = string.Empty });

        }
    }
}