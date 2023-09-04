using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Data;
using UserManager.Data;

namespace MediLab.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class AppointmentsController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IToastNotification toastNotification;

        public AppointmentsController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            this.context = context;
            this.toastNotification = toastNotification;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int appId)
        {
            var appointment = await context.Appointments.FindAsync(appId);

            if (appointment == null)
            {
                return NotFound();
            }

            context.Appointments.Remove(appointment);
            context.SaveChanges();
            toastNotification.AddSuccessToastMessage("Role was deleted successfully");
            return Ok();
        }
    }
}
