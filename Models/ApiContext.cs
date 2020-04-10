using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RestApi.Models;

namespace RestApi.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Battery>()
                .HasOne(p => p.buildings)
                .WithMany(b => b.batteries)
                .HasForeignKey(p => p.building_id);

            modelBuilder.Entity<Column>()
                .HasOne(p => p.batteries)
                .WithMany(b => b.columns)
                .HasForeignKey(p => p.battery_id);

            modelBuilder.Entity<Elevator>()
                .HasOne(p => p.columns)
                .WithMany(b => b.elevators)
                .HasForeignKey(p => p.column_id);
        }

        public DbSet<Building> buildings { get; set; }
        public DbSet<Battery> batteries { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Elevator> elevators { get; set; }
        public DbSet<Lead> leads { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Intervention> interventions { get; set; }
    }
}