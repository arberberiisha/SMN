using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMN.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SMN.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVm login)
        {
            IdentityUser identityUser = await userManager.FindByEmailAsync(login.Email);
            SignInResult signInResult = await signInManager.PasswordSignInAsync(identityUser, login.Password, false, false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Ok("error loggin in");
            }
            
        }
    
        public async Task<IActionResult> CreateAsync()
        {
            var user = new IdentityUser
            {
                Email = "arber@test.com",
                EmailConfirmed = true,
                UserName = "Arber"
                
            };
            IdentityResult identityResult = await userManager.CreateAsync(user, "P@ssw0rd");
            if (identityResult.Succeeded)
            {
                return Ok("account created");
            }
            else
            {
                return Ok("account not created");
            }

        }
    
    
        public async Task<IActionResult> RolesAsync()
        {

            await roleManager.CreateAsync(new IdentityRole { Name = "Admin"});
            await roleManager.CreateAsync(new IdentityRole { Name = "Staff"});
            await roleManager.CreateAsync(new IdentityRole { Name = "Drejtor" });
            await roleManager.CreateAsync(new IdentityRole { Name = "Sekretar" });
            await roleManager.CreateAsync(new IdentityRole { Name = "Mesues" });
            await roleManager.CreateAsync(new IdentityRole { Name = "Nxenes" });

            return Ok("test");
        }

        public async Task<IActionResult> AddRoleAsync()
        {
            IdentityUser identityUser = await userManager.FindByEmailAsync("arber@test.com");
            await userManager.AddToRoleAsync(identityUser, "Admin");
            await userManager.AddToRoleAsync(identityUser, "Drejtor");
            await userManager.AddToRoleAsync(identityUser, "Staff");
            return Ok("added to roles");
        }   
    
    }
}