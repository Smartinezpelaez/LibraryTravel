using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryTravel.DAL.Models
{
    public partial class BrowserTravelContext : DbContext
    {
        public BrowserTravelContext()
        {
        }

        public BrowserTravelContext(DbContextOptions<BrowserTravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; } = null!;
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; } = null!;
        public virtual DbSet<Editoriale> Editoriales { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=BrowserTravel;User ID=UserBrowserTravel;Password=w2tsdv1pc0l;TrustServerCertificate=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>(entity =>
            {
                entity.Property(e => e.Apellido).HasMaxLength(45);

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<AutoresHasLibro>(entity =>
            {
                entity.ToTable("Autores_Has_Libros");

                entity.Property(e => e.AutoresId).HasColumnName("Autores_Id");

                entity.Property(e => e.LibrosIsbn).HasColumnName("Libros_ISBN");

                entity.HasOne(d => d.Autores)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.AutoresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Autores_Has_Libros_Autores");

                entity.HasOne(d => d.LibrosIsbnNavigation)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.LibrosIsbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Autores_Has_Libros_Libros");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Sede).HasMaxLength(45);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.HasIndex(e => e.EditorialesEntityId, "IX_Libros_editorialesEntityId");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.EditorialesEntityId).HasColumnName("editorialesEntityId");

                entity.Property(e => e.EditorialesId).HasColumnName("Editoriales_ID");

                entity.Property(e => e.NPaginas)
                    .HasMaxLength(45)
                    .HasColumnName("N_paginas");

                entity.Property(e => e.Titulo).HasMaxLength(45);

                entity.HasOne(d => d.EditorialesEntity)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EditorialesEntityId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
