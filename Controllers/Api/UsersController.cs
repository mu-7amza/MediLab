using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using UserManager.Models;

namespace UserManagment.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IToastNotification toastNotification;

        public RoleController(UserManager<ApplicationUser> userManager, IToastNotification _toastNotification)
        {
            _userManager = userManager;
            toastNotification = _toastNotification;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception();
            }
            toastNotification.AddSuccessToastMessage("User was deleted successfully");
            return Ok();
        }
    }
}
