using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcAppPOC.Entities;
using System.ComponentModel.DataAnnotations;

namespace MvcAppPOC.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<UserPrimaryInfo>? userPrimaryInfo { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MvcAppPOC.Entities.UserPrimaryInfo>? UserPrimaryInfo { get; set; }
    }
}