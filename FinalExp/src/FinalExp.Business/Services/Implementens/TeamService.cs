using FinalExp.Business.Exceptions;
using FinalExp.Business.Services.Interfaces;
using FinalExp.Core.Entities;
using FinalExp.Core.Repositories;
using System.ComponentModel.Design;
using System.Linq.Expressions;
namespace FinalExp.Business.Services.Implementens
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository;
        }
        public async Task CreateAsync(TeamMember entity)
        { 
            
            if (entity.Image != null)
            {

                if (entity.Image.ContentType != "image/png" && entity.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidContenttype("Image", "ancaq sekil yukle");

                }

                if (entity.Image.Length > 1048576)
                {
                    throw new InvalidImgSize("Image", "1 mb dan az yukle pul yazir ");

                }
                string path = "C:\\Users\\hesen\\OneDrive\\İş masası\\pustokclas\\WebApplication6\\wwwroot\\";
                string newFileName = FinalExp.Business.Helper.Helper.GetFileName(path, "upload", entity.Image);
               
                entity.ImageUrl= newFileName;
                await _teamRepository.Create(entity);
            };
        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException();
            var team = await _teamRepository.GetByIdAsync(x => x.Id == id);
            if (team == null) throw new NotImplementedException();
            _teamRepository.Delete(team);
        }

        public async Task<List<TeamMember>> GetAllAsync(Expression<Func<TeamMember, bool>>? expression = null, params string[]? includes)
        {
          return  await _teamRepository.GetAllAsync(expression, includes);
        }

        public async Task<TeamMember> GetByIdAsync(Expression<Func<TeamMember, bool>>? expression = null, params string[]? includes)
        {
          return await _teamRepository.GetByIdAsync(expression, includes);
        }

        public async Task SoftDelete(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException();
            var team= await _teamRepository.GetByIdAsync(x=>x.Id==id);
            if (team == null) throw new NotImplementedException();
            team.Isdeleted=!team.Isdeleted;
            

        }

        public async Task UpdateAsync(TeamMember entity)
        {
                var team=await _teamRepository.GetByIdAsync(x=>x.Id==entity.Id); if (team == null) throw new NotMember();
            
            if (entity.Image != null)
            {
                string folderPath = "upload";
                string pathh = "C:\\Users\\hesen\\OneDrive\\İş masası\\pustokclas\\WebApplication6\\wwwroot\\";
                string path = Path.Combine(pathh, folderPath, team.ImageUrl);

                


                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                if (entity.Image.ContentType != "image/png" && entity.Image.ContentType != "image/jpeg")
                {
                    throw new InvalidContenttype("Image", "ancaq sekil yukle");

                }

                if (entity.Image.Length > 1048576)
                {
                    throw new InvalidImgSize("Image", "1 mb dan az yukle pul yazir ");

                }
                string pathhh = "C:\\Users\\hesen\\OneDrive\\İş masası\\pustokclas\\WebApplication6\\wwwroot\\";
                string newFileName = FinalExp.Business.Helper.Helper.GetFileName(pathhh, "upload", entity.Image);

                team.ImageUrl = newFileName;

            }
            else
            {
                throw new InvalidImage("Image", "Image de yukle ");
            }
            
                
                team.Profession = entity.Profession;
                team.Name = entity.Name;
                team.UpdateTime=DateTime.Now;
                await _teamRepository.Save();
        }
    }
}
