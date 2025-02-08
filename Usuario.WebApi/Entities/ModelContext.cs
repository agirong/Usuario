using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Usuario.WebApi.Entities;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=USER_AARON;Password=aAron2025$;Data Source=localhost:1521/xe;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("USER_AARON")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("USUARIO_PK");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Idusuario)
                .HasColumnType("NUMBER")
                .HasColumnName("IDUSUARIO");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Estado)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("ESTADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
