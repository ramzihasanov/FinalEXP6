using FinalExp.Core.Entities;
using FinalExp.MVC.Areas.manage.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExp.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);
            AppUser appUser = null;
            appUser = await userManager.FindByNameAsync(loginViewModel.Username);
            if (appUser == null)
            {
                ModelState.AddModelError("", "invalid username or paswword");
                return View();
            }
            var result = await signInManager.PasswordSignInAsync(appUser, loginViewModel.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "invalid username or paswword");
                return View();
            }

            return RedirectToAction("Index", "DashBoard");
        }
    }
}

