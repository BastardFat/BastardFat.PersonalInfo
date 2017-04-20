using BastardFat.PersonalInfo.DatabaseInteraction.Models.Entity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Context
{
    public class MainDbContext : DbContext
    {
        static MainDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public MainDbContext() : base("DefaultConnection") { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            

            modelBuilder.Entity<AppUser>()
                .ToTable("users");

            modelBuilder.Entity<Person>()
                .ToTable("persons");

            modelBuilder.Entity<AppUser>()
                .HasKey(x => x.Name);

            modelBuilder.Entity<Person>()
                .HasKey(x => x.Id);

        }

        class NpgsqlConfiguration : DbConfiguration
        {
            public NpgsqlConfiguration()
            {
                SetProviderServices("Npgsql", NpgsqlServices.Instance);
                SetProviderFactory("Npgsql", NpgsqlFactory.Instance);
                SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
            }
        }

    }
}
 