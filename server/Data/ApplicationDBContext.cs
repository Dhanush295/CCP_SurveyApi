using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Model;

namespace server.Data
{
    public class ApplicationDBContext : DbContext
    {
        
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<SurveyOne> SureyOnes {get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyOne>()
                .HasKey(s => s.ID);

            modelBuilder.Entity<SurveyOne>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<SurveyOne>()
                .Property(s => s.ZipCode)
                .HasMaxLength(5)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => v.PadLeft(5, '0'));
        }

    }
}