using FinalExp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Business.Services.Interfaces
{
    public interface ITeamService
    {

        Task CreateAsync(TeamMember entity);
        Task SoftDelete(int id);
        Task Delete(int id);
        Task<TeamMember> GetByIdAsync(Expression<Func<TeamMember, bool>>? expression = null,params string[]? includes);
        Task<List<TeamMember>> GetAllAsync(Expression<Func<TeamMember, bool>>? expression = null,params string[]? includes);
        Task UpdateAsync(TeamMember entity);
    }
}
