using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scheduler.Models;

namespace Scheduler.Data
{
    public class SchedulerContext : DbContext
    {
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users>Users { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public SchedulerContext (DbContextOptions<SchedulerContext> options)
            : base(options)
        {
        }

        //public DbSet<Scheduler.Models.Schedule> Schedule { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Schedule>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, Name = "Service Administrator" },
                new Roles { Id = 2, Name = "Engineer" }
                );
        }

    }

}