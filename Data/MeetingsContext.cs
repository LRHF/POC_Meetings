using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POC_Meetings.Models;

namespace POC_Meetings.Data
{
    public class MeetingsContext : DbContext
    {
        public MeetingsContext (DbContextOptions<MeetingsContext> options) : base(options)
        {
        }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().ToTable("Meeting");
        }
    }
}
