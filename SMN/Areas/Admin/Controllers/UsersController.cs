using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMN.Areas.Admin.Models;
using SMN.Data;
using SMN.Data.Entities;

namespace SMN.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;

        public UsersController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RegisterUserVm register)
        {
            var identity = new IdentityUser
            {
                Email = register.Email,
                EmailConfirmed = true,
                UserName = register.Email,
            };

            IdentityResult identityResult = await userManager.CreateAsync(identity, register.Password);
            if (identityResult.Succeeded)
            {
                SmnUser user = new SmnUser
                {
                    DataELindjes = register.DataELindjes,
                    Emri = register.Emri,
                    EmriPrindit = register.EmriPrindit,
                    Foto = register.Foto,
                    Mbiemri = register.Mbiemri,
                    Identity = identity,
                };
                IdentityResult result = await userManager.AddToRoleAsync(identity, register.Roli);
                context.SmnUser.Add(user);
                await context.SaveChangesAsync();
                return Ok("New User Created");
            }
            else
            {
                return Ok("some error");
            }



            return View();
        }
    }
}