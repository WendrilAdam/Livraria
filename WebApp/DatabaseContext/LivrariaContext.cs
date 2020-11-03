using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Livraria.WebApp.Models;

namespace Livraria.WebApp.DatabaseContext
{
    public partial class LivrariaContext : DbContext
    {
        public LivrariaContext()
        {
        }

        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Livros> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=CASA-PC\\SQLEXPRESS,1433;Initial Catalog=Livraria;User ID=sa;Password=10081997w;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {

                entity.ToTable("CLIENTES");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(14);

                entity.Property(e => e.Dtnasc)
                    .HasColumnName("DTNASC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Livros>(entity =>
            {

                entity.ToTable("LIVROS");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasColumnName("AUTOR")
                    .HasMaxLength(50);

                entity.Property(e => e.Editora)
                    .IsRequired()
                    .HasColumnName("EDITORA")
                    .HasMaxLength(50);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
