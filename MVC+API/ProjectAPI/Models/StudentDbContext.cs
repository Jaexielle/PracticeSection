using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectAPI.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartmentsInfo> DepartmentsInfos { get; set; }

    public virtual DbSet<StudentInfo> StudentInfos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentsInfo>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__C223242299F03EBE");

            entity.ToTable("departmentsInfo");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DeparmentDetails)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("deparment_details");
            entity.Property(e => e.DepartmentAbrv)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("department_abrv");
        });

        modelBuilder.Entity<StudentInfo>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__studentI__2A33069AEB87558A");

            entity.ToTable("studentInfo");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Department).HasColumnName("department");
            entity.Property(e => e.EmailAddreiss)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_addreiss");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("student_name");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.StudentInfos)
                .HasForeignKey(d => d.Department)
                .HasConstraintName("FK__studentIn__depar__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
