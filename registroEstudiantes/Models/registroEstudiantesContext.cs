﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace registroEstudiantes.Models
{
    public partial class registroEstudiantesContext : DbContext
    {
        public registroEstudiantesContext()
        {
        }

        public registroEstudiantesContext(DbContextOptions<registroEstudiantesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JERSON\\SQLEXPRESS;Database=registroEstudiantes;User Id=sa;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.ToTable("estudiantes");

                entity.Property(e => e.IdEstudiante).HasColumnName("id_Estudiante");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IdMateria).HasColumnName("id_Materia");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("FK__estudiant__id_Ma__4BAC3F29");
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.ToTable("materias");

                entity.Property(e => e.IdMateria).HasColumnName("id_Materia");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });
        }
    }
}
