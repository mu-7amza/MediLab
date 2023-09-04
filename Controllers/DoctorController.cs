using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UserManager.Data;
using UserManager.Models;
using UserManagment.ViewModels;

namespace UserManagment.Controllers
{
    [Authorize(Roles = "Doctor")]

    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public DoctorController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var list = await context.Appointments.ToListAsync(); 
            return View(list);
        }
        public async Task<IActionResult> Appointments()
        {
            var appointments = await context.Appointments.Where(x=>x.DoctorId == userManager.GetUserId(HttpContext.User)).Select(appointment => new AppointmentViewModel
            {
                Id = appointment.Id,
                FullName = appointment.FullName,
                Phone = appointment.Phone,
                Email = appointment.Email,
                Area = appointment.Area,
                City = appointment.City,
                State = appointment.State,
                Date = appointment.Date,
                Time = appointment.Time,
                Doctor = appointment.Doctor,
                isAccepted = appointment.isAccepted
                
            }).ToListAsync();
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }
        public async Task<IActionResult> AcceptedAppointments()
        {
            var acceptedAppointments = await context.Appointments.Where(x => x.DoctorId == userManager.GetUserId(HttpContext.User) && x.isAccepted == true).Select(appointment => new AppointmentViewModel
            {
                Id = appointment.Id,
                FullName = appointment.FullName,
                Phone = appointment.Phone,
                Email = appointment.Email,
                Area = appointment.Area,
                City = appointment.City,
                State = appointment.State,
                Date = appointment.Date,
                Time = appointment.Time,
                Doctor = appointment.Doctor,
                isAccepted = appointment.isAccepted
                

            }).ToListAsync();
            if (acceptedAppointments == null)
            {
                return NotFound();
            }
            return View(acceptedAppointments);
        }
        public async Task<IActionResult> RejectedAppointments()
        {
            var acceptedAppointments = await context.Appointments.Where(x => x.DoctorId == userManager.GetUserId(HttpContext.User) && x.isAccepted == false).Select(appointment => new AppointmentViewModel
            {
                Id = appointment.Id,
                FullName = appointment.FullName,
                Phone = appointment.Phone,
                Email = appointment.Email,
                Area = appointment.Area,
                City = appointment.City,
                State = appointment.State,
                Date = appointment.Date,
                Time = appointment.Time,
                Doctor = appointment.Doctor,
                isAccepted = appointment.isAccepted


            }).ToListAsync();
            if (acceptedAppointments == null)
            {
                return NotFound();
            }
            return View(acceptedAppointments);
        }

        public async Task<IActionResult> Details(int appId)
        {
            var appointment = await context.Appointments.FindAsync(appId);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);

        }
        
            
        }
    }

