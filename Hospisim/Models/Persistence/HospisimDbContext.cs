using Hospisim.Models;
using Hospisim.Models.Entities;
using HOSPISIM.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospisim.Data
{
    public class HospisimDbContext : DbContext
    {
        public HospisimDbContext(DbContextOptions<HospisimDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }
        public DbSet<ProfissionalSaude> ProfissionaisSaude { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Prescricao> Prescricoes { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Internacao> Internacoes { get; set; }
        public DbSet<AltaHospitalar> AltasHospitalares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API para relacionamentos e constraints

            modelBuilder.Entity<Prontuario>()
                .HasOne(p => p.Paciente)
                .WithMany(p => p.Prontuarios)
                .HasForeignKey(p => p.PacienteId);

            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Prontuario)
                .WithMany(p => p.Atendimentos)
                .HasForeignKey(a => a.ProntuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Atendimento>()
                .HasOne(a => a.Profissional)
                .WithMany()
                .HasForeignKey(a => a.ProfissionalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prescricao>()
                .HasOne(p => p.Atendimento)
                .WithMany(a => a.Prescricoes)
                .HasForeignKey(p => p.AtendimentoId);

            modelBuilder.Entity<Prescricao>()
                .HasOne(p => p.Profissional)
                .WithMany()
                .HasForeignKey(p => p.ProfissionalId);

            modelBuilder.Entity<Exame>()
                .HasOne(e => e.Atendimento)
                .WithMany(a => a.Exames)
                .HasForeignKey(e => e.AtendimentoId);

            modelBuilder.Entity<Internacao>()
                .HasOne(i => i.Atendimento)
                .WithOne(a => a.Internacao)
                .HasForeignKey<Internacao>(i => i.AtendimentoId);

            
            modelBuilder.Entity<Internacao>()
                .HasOne(i => i.Paciente)
                .WithMany(p => p.Internacoes)
                .HasForeignKey(i => i.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);
            

            modelBuilder.Entity<AltaHospitalar>()
                .HasOne(a => a.Internacao)
                .WithOne(i => i.AltaHospitalar)
                .HasForeignKey<AltaHospitalar>(a => a.InternacaoId);

            modelBuilder.Entity<ProfissionalSaude>()
                .HasOne(p => p.Especialidade)
                .WithMany(e => e.Profissionais)
                .HasForeignKey(p => p.EspecialidadeId);
        }
    }
}
