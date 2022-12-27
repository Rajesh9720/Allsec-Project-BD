using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmpFD.Models;

public partial class EmpInsuContext : DbContext
{
    public EmpInsuContext()
    {
    }

    public EmpInsuContext(DbContextOptions<EmpInsuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeInsu> EmployeeInsus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeInsu>(entity =>
        {
            entity.HasKey(e => e.EmployeeCode).HasName("PK__Employee__1F64254990DF4B00");

            entity.ToTable("EmployeeInsu");

            entity.Property(e => e.InsurenceNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomineeAge)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomineeDob)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NomineeDOB");
            entity.Property(e => e.NomineeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NomineeType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
