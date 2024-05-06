using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TacoFastFoodAPI.Models;

public partial class FastFoodTacoDbContext : DbContext
{
    public FastFoodTacoDbContext()
    {
    }

    public FastFoodTacoDbContext(DbContextOptions<FastFoodTacoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Combo> Combos { get; set; }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<Taco> Tacos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MYPC;Database=FastFoodTacoDb;Trusted_Connection=True;;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Combo>(entity =>
        {
            entity.HasKey(e => e.ComboId).HasName("PK__Combo__DD42582EB6BA1ED2");

            entity.ToTable("Combo");

            entity.Property(e => e.ComboName).HasMaxLength(255);
            entity.Property(e => e.DrinkId).HasColumnName("DrinkID");
            entity.Property(e => e.TacoId).HasColumnName("TacoID");

            entity.HasOne(d => d.Drink).WithMany(p => p.Combos)
                .HasForeignKey(d => d.DrinkId)
                .HasConstraintName("FK__Combo__DrinkID__3E52440B");

            entity.HasOne(d => d.Taco).WithMany(p => p.Combos)
                .HasForeignKey(d => d.TacoId)
                .HasConstraintName("FK__Combo__TacoID__3D5E1FD2");
        });

        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.DrinkId).HasName("PK__Drink__C094D3C81EEA0C60");

            entity.ToTable("Drink");

            entity.Property(e => e.DrinkId).HasColumnName("DrinkID");
            entity.Property(e => e.DrinkName).HasMaxLength(255);
        });

        modelBuilder.Entity<Taco>(entity =>
        {
            entity.HasKey(e => e.TacoId).HasName("PK__Taco__E8183639C7AF6C4B");

            entity.ToTable("Taco");

            entity.Property(e => e.TacoId).HasColumnName("TacoID");
            entity.Property(e => e.TacoName).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CEECDCE85");

            entity.Property(e => e.ApiKey).HasMaxLength(10);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
