using System.ComponentModel.DataAnnotations;

namespace HTML_Previewer_Web_App.Models.Samples
{
    public class SampleFormModel
    {
        public string Id { get; init; }

        [Required]
        public string Code { get; init; }
    }
}
