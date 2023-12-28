﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppCoreMVC.Models
{
    public partial class School2023DbContext : DbContext
    {
        public School2023DbContext()
        {
        }

        public School2023DbContext(DbContextOptions<School2023DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-HURDBM1G;database=School2023Db;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.CourseCategory, "UQ__Category__672ECC6D069AE159")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CourseCategory).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CourseCategoryId).HasColumnName("CourseCategoryID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.CourseCategory)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CourseCategoryId)
                    .HasConstraintName("FK__Course__CourseCa__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
