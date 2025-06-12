using Hospisim.Models.Entities;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HOSPISIM.Models
{
    public class Atendimento
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Local { get; set; }

        public Guid ProntuarioId { get; set; }
        public Prontuario Prontuario { get; set; }

        public Guid ProfissionalSaudeId { get; set; }
        public ProfissionalSaude ProfissionalSaude { get; set; }

        public ICollection<Prescricao> Prescricoes { get; set; }
        public ICollection<Exame> Exames { get; set; }

        public Internacao Internacao { get; set; } 
    }
}
