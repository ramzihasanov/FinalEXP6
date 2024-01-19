
using FinalExp.Business.Services.Interfaces;
using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalExp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ITeamService teamService)
        {
            this.teamService = teamService;
        }
        private readonly ITeamService teamService;

     

        public async Task<IActionResult> Index()
        {
            List<TeamMember > members = await teamService.GetAllAsync();
            return View(members);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       

    }
}