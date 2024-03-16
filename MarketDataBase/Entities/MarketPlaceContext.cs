using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MarketDataBase.Entities;

public partial class MarketPlaceContext : DbContext
{
    public MarketPlaceContext()
    {
    }

    public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PickupPoint> PickupPoints { get; set; }

    public virtual DbSet<PickupPointOrder> PickupPointOrders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VUKKERT;Database=MarketPlace;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("ITEM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
            entity.Property(e => e.Picture)
                .HasMaxLength(1)
                .HasColumnName("PICTURE");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("PRICE");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("RATING");
            entity.Property(e => e.Vendor).HasColumnName("VENDOR");

            entity.HasOne(d => d.VendorNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.Vendor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ITEM_VENDOR");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("ORDER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Item).HasColumnName("ITEM");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ORDER_DATE");
            entity.Property(e => e.PickupPoint).HasColumnName("PICKUP_POINT");
            entity.Property(e => e.User).HasColumnName("USER");

            entity.HasOne(d => d.ItemNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Item)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_ITEM");

            entity.HasOne(d => d.PickupPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PickupPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_PICKUP_POINT");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_USER");
        });

        modelBuilder.Entity<PickupPoint>(entity =>
        {
            entity.ToTable("PICKUP_POINT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Picture)
                .HasMaxLength(1)
                .HasColumnName("PICTURE");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("RATING");
        });

        modelBuilder.Entity<PickupPointOrder>(entity =>
        {
            entity.ToTable("PICKUP_POINT_ORDER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Order).HasColumnName("ORDER");
            entity.Property(e => e.PickupDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PICKUP_DATE");
            entity.Property(e => e.PickupPoint).HasColumnName("PICKUP_POINT");
            entity.Property(e => e.Staff).HasColumnName("STAFF");
            entity.Property(e => e.User).HasColumnName("USER");

            entity.HasOne(d => d.OrderNavigation).WithMany(p => p.PickupPointOrders)
                .HasForeignKey(d => d.Order)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PICKUP_POINT_ORDER_ORDER");

            entity.HasOne(d => d.PickupPointNavigation).WithMany(p => p.PickupPointOrders)
                .HasForeignKey(d => d.PickupPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PICKUP_POINT_ORDER_PICKUP_POINT");

            entity.HasOne(d => d.StaffNavigation).WithMany(p => p.PickupPointOrders)
                .HasForeignKey(d => d.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PICKUP_POINT_ORDER_STAFF");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.PickupPointOrders)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PICKUP_POINT_ORDER_USER");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("ROLE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable("STAFF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PickupPoint).HasColumnName("PICKUP_POINT");
            entity.Property(e => e.Picture)
                .HasMaxLength(1)
                .HasColumnName("PICTURE");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("RATING");
            entity.Property(e => e.User).HasColumnName("USER");

            entity.HasOne(d => d.PickupPointNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.PickupPoint)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STAFF_PICKUP_POINT");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STAFF_USER");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("LOGIN");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Role).HasColumnName("ROLE");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_ROLE");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.ToTable("VENDOR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("NAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
