using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManager.Models;

namespace UserManagment.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string? Doctor { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string? DoctorId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        public bool? isAccepted { get; set; }



    }
}
