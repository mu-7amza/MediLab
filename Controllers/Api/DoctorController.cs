using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Data;
using UserManager.Data;

namespace MediLab.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IToastNotification toastNotification;

        public DoctorController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            this.context = context;
            this.toastNotification = toastNotification;
        }

        [HttpPut]
        [Route("accept")]
        public async Task<IActionResult> Accept(int appId)
        {
            var appointment = await context.Appointments.FindAsync(appId);

            if (appointment == null)
            {
                return NotFound();
            }
            appointment.isAccepted = true;

            context.Appointments.Update(appointment);
            context.SaveChanges();
            toastNotification.AddSuccessToastMessage("Role was deleted successfully");
            return Ok();
        }
        [HttpPut]
        [Route("reject")]
        public async Task<IActionResult> Reject(int appId)
        {
            var appointment = await context.Appointments.FindAsync(appId);

            if (appointment == null)
            {
                return NotFound();
            }
            appointment.isAccepted = false;

            context.Appointments.Update(appointment);
            context.SaveChanges();
            toastNotification.AddSuccessToastMessage("Role was deleted successfully");
            return Ok();
        }
        [HttpPut]
        [Route("undo")]
        public async Task<IActionResult> Undo(int appId)
        {
            var appointment = await context.Appointments.FindAsync(appId);

            if (appointment == null)
            {
                return NotFound();
            }
            appointment.isAccepted = null;

            context.Appointments.Update(appointment);
            context.SaveChanges();
            toastNotification.AddSuccessToastMessage("Role was deleted successfully");
            return Ok();
        }

    }
}
