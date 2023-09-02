using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManager.Data;
using UserManagment.ViewModels;

namespace UserManagment.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext context;

        public DoctorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await context.Appointments.ToListAsync(); 
            return View(list);
        }
        public async Task<IActionResult> TotalAppointments()
        {
            var appointments = await context.Appointments.Select(appointment => new AppointmentViewModel
            {
                FullName = appointment.FullName,
                Phone = appointment.Phone,
                Email = appointment.Email,
                Area = appointment.Area,
                City = appointment.City,
                State = appointment.State,
                Date = appointment.Date,
                Time = appointment.Time,
            }).ToListAsync();
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }
            
        }
    }

