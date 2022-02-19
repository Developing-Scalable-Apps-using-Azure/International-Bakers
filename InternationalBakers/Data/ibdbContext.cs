using System;
using InternationalBakers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InternationalBakers.Data
{
    public partial class ibdbContext : DbContext
    {
        public ibdbContext()
        {
        }

        public ibdbContext(DbContextOptions<ibdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cookies> Cookies { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
         //       optionsBuilder.UseSqlServer("Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ibdb");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cookies>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.HasOne(d => d.Cookie)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.CookieId)
                    .HasConstraintName("CookieForeignKey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("OrderForeignKey");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("StoreForeignKey");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
