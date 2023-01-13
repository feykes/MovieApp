using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductionCountries>().HasNoKey();
            builder.Entity<SpokenLanguages>().HasNoKey();
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<ProductionCompanies> ProductionCompanies { get; set; }
        public DbSet<ProductionCountries> ProductionCountries { get; set; }
        public DbSet<SpokenLanguages> SpokenLanguages { get; set; }
    }
}
