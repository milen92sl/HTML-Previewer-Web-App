namespace HTML_Previewer_Web_App.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public ICollection<Sample> Samples { get; init; } = new HashSet<Sample>();
    }
}
