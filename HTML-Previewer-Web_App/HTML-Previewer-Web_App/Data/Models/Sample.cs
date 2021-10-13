namespace HTML_Previewer_Web_App.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataWebConstants;

    public class Sample
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Code { get; set; }

        public DateTime Creation { get; set; }

        public DateTime LastEdit { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set;}


    }
}
