﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using UserManager.ViewModels;

namespace UserManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IToastNotification toastNotification;

        public RoleController(RoleManager<IdentityRole> roleManager, IToastNotification toastNotification)
        {
            _roleManager = roleManager;
            this.toastNotification = toastNotification;
        }


        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {
            if(!ModelState.IsValid)
                return View("Index",await _roleManager.Roles.ToListAsync());

            if(await _roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("Name", "Role is exists !");
                return View("Index", await _roleManager.Roles.ToListAsync());
            }

            await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
            toastNotification.AddSuccessToastMessage("Role was added successfuly !");
            return RedirectToAction(nameof(Index));
        }

       
    }
}
