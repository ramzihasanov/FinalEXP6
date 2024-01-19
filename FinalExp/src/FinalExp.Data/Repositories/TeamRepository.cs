using FinalExp.Core.Entities;
using FinalExp.Core.Repositories;
using FinalExp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Data.Repositories
{
    public class TeamRepository : GenericRepository<TeamMember>, ITeamRepository
    {
        public TeamRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
