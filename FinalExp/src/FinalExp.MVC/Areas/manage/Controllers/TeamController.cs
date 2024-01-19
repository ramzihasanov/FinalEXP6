using FinalExp.Business.Services.Interfaces;
using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalExp.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            this._teamService = teamService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
           var teams= await _teamService.GetAllAsync();
            return View(teams);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamMember team)
        {
            await _teamService.CreateAsync(team);
           return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TeamMember teamMember)
        {
            await _teamService.UpdateAsync(teamMember);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
            var team = await _teamService.GetByIdAsync(x => x.Id == id);
            if (team != null)
            {
                team.Isdeleted = !team.Isdeleted;
                team.DeleteTime = DateTime.Now;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _teamService.GetByIdAsync(x => x.Id == id);
            if (team != null)
            {
                _teamService.Delete(id);
            }

            return Ok();
        }
    }
}
