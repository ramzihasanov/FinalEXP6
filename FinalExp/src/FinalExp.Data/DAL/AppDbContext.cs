using FinalExp.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace FinalExp.Data.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
