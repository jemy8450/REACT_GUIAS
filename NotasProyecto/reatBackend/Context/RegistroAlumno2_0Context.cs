﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using reatBackend.Models;

namespace reatBackend.Context;

public partial class RegistroAlumno2_0Context : DbContext
{
    public RegistroAlumno2_0Context()
    {
    }

    public RegistroAlumno2_0Context(DbContextOptions<RegistroAlumno2_0Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source = JEREMYGAMER8450\\SQLEXPRESS;Initial Catalog = RegistroAlumno2.0; User ID = segura;Password = segura90; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__alumno__3213E83F2DD6AF39");

            entity.ToTable("alumno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__asignatu__3213E83F99DF47CC");

            entity.ToTable("asignatura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Profesor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profesor");

            entity.HasOne(d => d.ProfesorNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.Profesor)
                .HasConstraintName("FK__asignatur__profe__4E88ABD4");
        });

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__califica__3213E83F02A521B5");

            entity.ToTable("calificacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.MatriculaId).HasColumnName("matriculaId");
            entity.Property(e => e.Nota).HasColumnName("nota");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

            entity.HasOne(d => d.Matricula).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.MatriculaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__calificac__matri__5535A963");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__matricul__3213E83F3A464140");

            entity.ToTable("matricula");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlumnoId).HasColumnName("alumnoId");
            entity.Property(e => e.AsignaturaId).HasColumnName("asignaturaId");

            entity.HasOne(d => d.Alumno).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__matricula__alumn__5165187F");

            entity.HasOne(d => d.Asignatura).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.AsignaturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__matricula__asign__52593CB8");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Usuario).HasName("PK__profesor__9AFF8FC71B78DEDC");

            entity.ToTable("profesor");

            entity.Property(e => e.Usuario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pass");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
