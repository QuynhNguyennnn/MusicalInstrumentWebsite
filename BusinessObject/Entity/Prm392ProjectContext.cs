using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject.Entity;

public partial class Prm392ProjectContext : DbContext
{
    public Prm392ProjectContext()
    {
    }

    public Prm392ProjectContext(DbContextOptions<Prm392ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillProduct> BillProducts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartProduct> CartProducts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =MINHTAM; database = PRM392_Project;uid=sa;pwd=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Gmail)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeopleId).HasColumnName("PeopleID");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.People).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.PeopleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Customer");

            entity.HasOne(d => d.PeopleNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.PeopleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Staff");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.ToTable("Bill");

            entity.Property(e => e.BillId)
                .ValueGeneratedNever()
                .HasColumnName("BillID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PurchaseDate).HasColumnType("date");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bills)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bill_Customer");

            entity.HasOne(d => d.Staff).WithMany(p => p.Bills)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bill_Staff");
        });

        modelBuilder.Entity<BillProduct>(entity =>
        {
            entity.ToTable("Bill_Product");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BillId).HasColumnName("BillID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Bill).WithMany(p => p.BillProducts)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bill_Product_Bill");

            entity.HasOne(d => d.Product).WithMany(p => p.BillProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bill_Product_Product");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("CartID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Customer");
        });

        modelBuilder.Entity<CartProduct>(entity =>
        {
            entity.ToTable("Cart_Product");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Product_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Product_Product");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Comment)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("StaffID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
