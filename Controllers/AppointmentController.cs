using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UserManager.Data;
using UserManager.Models;
using UserManager.ViewModels;
using UserManagment.Models;
using UserManagment.ViewModels;

namespace UserManagment.Controllers
{

    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public AppointmentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await context.Appointments.Where(x => x.DoctorId == userManager.GetUserId(HttpContext.User)).Select(appointment => new AppointmentViewModel
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
                Doctor = appointment.Doctor
            }).ToListAsync();
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }

        public async Task<IActionResult> Create()
        {
            var doctorNames = await userManager.GetUsersInRoleAsync("Doctor");
            ViewBag.DoctorsSelectList = new SelectList(doctorNames.Select(x => "Dr/ " + x.FirstName + " " + x.LastName));
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            appointment.DoctorId = userManager.GetUserId(HttpContext.User);
            await context.AddAsync(appointment);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string userId)
        {
            var appointment = await context.Appointments.FindAsync(userId);

            if (appointment == null)
            {
                return NotFound();
            }

            var viewModel = new AppointmentViewModel
            {
                Id = appointment.Id,
                FullName = appointment.FullName,
                Phone = appointment.Phone,
                Email = appointment.Email,
                Doctor = appointment.Doctor,
                DoctorId = appointment.DoctorId,
                Time = appointment.Time,
                Date = appointment.Date,
                Area = appointment.Area,
                City = appointment.City,
                State = appointment.State,

            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentViewModel model)
        {
            var appointment = await context.Appointments.FindAsync(model.Id);

            if (appointment == null)
            {
                return NotFound();
            }

            appointment.FullName = model.FullName;
            appointment.Phone = model.Phone;
            appointment.Email = model.Email;
            appointment.City = model.City;
            appointment.State = model.State;
            appointment.Area = model.Area;
            appointment.Date = model.Date;
            appointment.Time = model.Time;
            appointment.Doctor = model.Doctor;

            context.Appointments.Update(appointment);


            return RedirectToAction(nameof(Index));

        }



    }
}

