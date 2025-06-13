using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class Prescricao
    {
        public Guid Id { get; set; }

        [ForeignKey("Atendimento")]
        public Guid AtendimentoId { get; set; }

        [ForeignKey("Profissional")]
        public Guid ProfissionalId { get; set; }


        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Frequencia { get; set; }
        public string ViaAdministracao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Observacoes { get; set; }
        public string StatusPrescricao { get; set; }
        public string? ReacoesAdversas { get; set; }
    }
}
