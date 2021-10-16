namespace HTML_Previewer_Web_App.Models.Samples
{
    using System.ComponentModel.DataAnnotations;

    public class SampleFormModel
    {
        public string Id { get; init; }

        [Required]
        public string Code { get; init; }
    }
}
