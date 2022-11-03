using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext {

        public TurnosContext(DbContextOptions<TurnosContext> options) : base(options) { }

        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Especialidad>( entidad => {
                entidad.ToTable("Especialidad");
                entidad.HasKey(e => e.IdEspecialidad);
                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>( entidad => {
                entidad.ToTable("Paciente");
                entidad.HasKey(e => e.IdPaciente);
                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Dni)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);
                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
                entidad.Property(e => e.Email)
                .IsRequired(false)
                .HasMaxLength(100)
                .IsUnicode(false);
                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entidad => {
                entidad.ToTable("Medico");
                entidad.HasKey(e => e.IdMedico);
                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Matricula)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
                entidad.Property(e => e.Email)
                .IsRequired(false)
                .HasMaxLength(100)
                .IsUnicode(false);
                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Localidad)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.HorarioEntrada)
                .IsRequired()
                .IsUnicode(false);
                entidad.Property(e => e.HorarioSalida)
                .IsRequired()
                .IsUnicode(false);
            });
        
            modelBuilder.Entity<MedicoEspecialidad>(entidad => {
                entidad.ToTable("MedicoEspecialidad");
                entidad.HasKey(e => new { e.IdMedico, e.IdEspecialidad });
                entidad.HasOne(e => e.Medico)
                .WithMany(e => e.MedicoEspecialidad)
                .HasForeignKey(e => e.IdMedico);
                entidad.HasOne(e => e.Especialidad)
                .WithMany(e => e.MedicoEspecialidad)
                .HasForeignKey(e => e.IdEspecialidad);
            });
        }

    }
}