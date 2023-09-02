using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UserManager.Models;

namespace UserManagment.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
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

        [ForeignKey(nameof(ApplicationUser))]
        public string? DoctorId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string Doctor { get; set; }
        
    }
}
