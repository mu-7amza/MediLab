using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UserManagment.Models;

namespace UserManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public byte[]? ProfilePicture { get; set; }

    }
}
