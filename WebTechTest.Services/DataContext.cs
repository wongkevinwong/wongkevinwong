using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebTechTest.Models.Test1;
using WebTechTest.Models.Test3;

namespace WebTechTest.Services
{
    public class DataContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateRelationships(modelBuilder);
        }

        private void CreateRelationships(ModelBuilder modelBuilder)
        {
            CreatePersonAdGroupRelationship(modelBuilder);
        }

        private void CreatePersonAdGroupRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonAdGroup>().HasKey(pa => new { pa.PersonId, pa.AdGroupId });
            modelBuilder.Entity<PersonAdGroup>().HasOne(pa => pa.AdGroup).WithMany(adGroup => adGroup.PersonAdGroups).HasForeignKey(a => a.AdGroupId);
            modelBuilder.Entity<PersonAdGroup>().HasOne(pa => pa.Person).WithMany(p => p.PersonAdGroups).HasForeignKey(p => p.PersonId);
        }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            //TODO:remove this
            //this.Database.EnsureDeleted();

            var created = this.Database.EnsureCreated();

            if (created)
            {
                new SetupData().CreateData(this);
            }
        }


        public DbSet<Person> People { get; set; }
        public DbSet<AdGroup> AdGroups { get; set; }
        public DbSet<PersonAdGroup> PeopleAdGroups { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
    }
}
