using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Datos.Entidades
{
    public partial class api_dbContext : DbContext
    {
        public api_dbContext()
        {
        }

        public api_dbContext(DbContextOptions<api_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ColaboradorSucursal> ColaboradorSucursals { get; set; } = null!;
        public virtual DbSet<Colaboradore> Colaboradores { get; set; } = null!;
        public virtual DbSet<Sucursale> Sucursales { get; set; } = null!;
        public virtual DbSet<Transportista> Transportistas { get; set; } = null!;
        public virtual DbSet<Viaje> Viajes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PENIA\\SQLEXPRESS;Database=api_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColaboradorSucursal>(entity =>
            {
                entity.HasKey(e => e.IdColaboradorSucursal);

                entity.ToTable("colaborador_sucursal");

                entity.Property(e => e.IdColaboradorSucursal).HasColumnName("id_colaborador_sucursal");

                entity.Property(e => e.Distancia)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("distancia");

                entity.Property(e => e.IdColaborador).HasColumnName("id_colaborador");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.HasOne(d => d.IdColaboradorNavigation)
                    .WithMany(p => p.ColaboradorSucursals)
                    .HasForeignKey(d => d.IdColaborador)
                    .HasConstraintName("FK_colaborador_sucursal_colaboradores");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.ColaboradorSucursals)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_colaborador_sucursal_sucursales");
            });

            modelBuilder.Entity<Colaboradore>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("PK__colabora__BA4DA9461367E606");

                entity.ToTable("colaboradores");

                entity.Property(e => e.IdColaborador).HasColumnName("id_colaborador");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Perfil)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("perfil");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK__sucursal__6D39A9327F60ED59");

                entity.ToTable("sucursales");

                entity.Property(e => e.IdSucursal).HasColumnName("id_sucursal");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Transportista>(entity =>
            {
                entity.HasKey(e => e.IdTransportista)
                    .HasName("PK__transpor__6D39A9320F975522");

                entity.ToTable("transportistas");

                entity.Property(e => e.IdTransportista).HasColumnName("id_transportista");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tarifa)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("tarifa");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(e => e.IdViajes);

                entity.ToTable("viajes");

                entity.Property(e => e.IdViajes).HasColumnName("id_viajes");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdColaboradorSucursal).HasColumnName("id_colaborador_sucursal");

                entity.Property(e => e.IdTransportista).HasColumnName("id_transportista");

                entity.Property(e => e.Pago)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("pago");

                entity.HasOne(d => d.IdColaboradorSucursalNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdColaboradorSucursal)
                    .HasConstraintName("FK_viajes_colaborador_sucursal");

                entity.HasOne(d => d.IdTransportistaNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdTransportista)
                    .HasConstraintName("FK_viajes_transportistas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
