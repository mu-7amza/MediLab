using System.ComponentModel.DataAnnotations;

namespace MediLab.ViewModels
{
    public class DoctorListViewModel
    {
        public string DoctorId { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }

    }
}
