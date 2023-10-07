using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TelemetryCar.Models;

namespace TelemetryCar.Data;

public partial class CarDbContext : DbContext
{
    public CarDbContext()
    {
    }

    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarInfo> CarInfos { get; set; }

    public virtual DbSet<ModelInfo> ModelInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;UserId=postgres;Password=postgres;Database=car_db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_trgm");

        modelBuilder.Entity<CarInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_info_pkey");

            entity.ToTable("car_info");

            entity.HasIndex(e => e.LicensePlate, "license_plate_index")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AmountCharge)
                .HasDefaultValueSql("0")
                .HasColumnName("amount_charge");
            entity.Property(e => e.AverageSpeed)
                .HasDefaultValueSql("0")
                .HasColumnName("average_speed");
            entity.Property(e => e.Busy)
                .HasDefaultValueSql("false")
                .HasColumnName("busy");
            entity.Property(e => e.LicensePlate)
                .HasColumnType("character varying")
                .HasColumnName("license_plate");
            entity.Property(e => e.Mileage)
                .HasDefaultValueSql("0")
                .HasColumnName("mileage");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.TemperatureEngine)
                .HasDefaultValueSql("80")
                .HasColumnName("temperature_engine");
            entity.Property(e => e.TemperatureInside)
                .HasDefaultValueSql("15")
                .HasColumnName("temperature_inside");
            entity.Property(e => e.TemperatureOut)
                .HasDefaultValueSql("15")
                .HasColumnName("temperature_out");

            entity.HasOne(d => d.Model).WithMany(p => p.CarInfos)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_model_id");
        });

        modelBuilder.Entity<ModelInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("model_info_pkey");

            entity.ToTable("model_info");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
