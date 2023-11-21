using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Mvc;
 
namespace dotnetapp.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Define DbSet properties for your custom application entities here, if needed.
        // For example, if you have a Player entity, you can add it ...
        public virtual DbSet<Player> Players{get;set;}
          public virtual DbSet<Team> Teams{get;set;}
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=PDb;trusted_connection=false;Persist Security Info=False;Encrypt=False;");
            }
        }
    }
}