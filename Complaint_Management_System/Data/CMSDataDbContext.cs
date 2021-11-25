using Complaint_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complaint_Management_System.Data
{
    public partial class CMSDataDbContext : DbContext
    {
        public CMSDataDbContext(DbContextOptions<CMSDataDbContext> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintResponse> ComplaintResponses { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().ToTable("UserProfile");
            modelBuilder.Entity<Complaint>().ToTable("Complaint");
            modelBuilder.Entity<ComplaintResponse>().ToTable("ComplaintResponse");
            modelBuilder.Entity<Announcement>().ToTable("Announcement");
        }
    }
}
