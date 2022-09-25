using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
	public class BaseDbContext : DbContext
	{
		public IConfiguration Configuration { get; set; }
		public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnology>(a =>
            {
                a.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "Java"), new(2, "C#"), new(3, "JavaScript") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            ProgrammingTechnology[] programmingTechnologyEntitySeeds = { new(1, 1, "Spring"), new(2, 1, "JSP"), new(3, 2, "WPF"), new (4,2,"ASP.NET") };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologyEntitySeeds);
        }
    }
}

