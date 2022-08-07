using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TripReport.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(150)]
        public string FullName { get; set; }
        [MaxLength(10)]
        public string EGN { get; set; }

    }
}
