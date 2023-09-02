using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Data;

namespace UserManagment.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IToastNotification toastNotification;

        public RolesController(RoleManager<IdentityRole> roleManager, IToastNotification toastNotification)
        {
            this.roleManager = roleManager;
            this.toastNotification = toastNotification;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound();
            }

            var result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                throw new Exception();
            }
            toastNotification.AddSuccessToastMessage("Role was deleted successfully");
            return Ok();
        }
    }
}
