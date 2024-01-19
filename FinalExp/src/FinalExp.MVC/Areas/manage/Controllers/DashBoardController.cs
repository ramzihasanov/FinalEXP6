using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExp.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashBoardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user = new AppUser
        //    {
        //        UserName = "Admin111",
        //        Fullname = "Admin",
        //    };

        //   var result=await _userManager.CreateAsync(user,"Admin111@");
        //    return Ok(result);
        //}

        //public async Task<IActionResult> CreateRoll() 
        //{
        //    var rol = new IdentityRole("Admin");

        //   await _roleManager.CreateAsync(rol);
        //    return Ok();
        //}
        //public async Task<IActionResult> AddToRoll()
        //{
        //    var user = await _userManager.FindByNameAsync("Admin111");
        //   var result= await _userManager.AddToRoleAsync(user, "Admin");
        //    return Ok(result);
        //}
    }
}
