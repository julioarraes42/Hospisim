using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class Exame
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public string Resultado { get; set; }

        [ForeignKey("Atendimento")]
        public Guid AtendimentoId { get; set; }


    }
}
