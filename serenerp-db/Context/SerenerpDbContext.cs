using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using serenerp_db.Models;

namespace serenerp_db.Context;

public partial class SerenerpDbContext : DbContext
{
    public SerenerpDbContext()
    {
    }

    public SerenerpDbContext(DbContextOptions<SerenerpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_bin")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Uid)
                .HasMaxLength(36)
                .HasColumnName("uid");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
