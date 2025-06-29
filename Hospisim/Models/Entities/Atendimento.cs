﻿using Hospisim.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Guid? ProntuarioId { get; set; }

        public Guid? ProfissionalId { get; set; }

        public Guid? PacienteId { get; set; }

        public ICollection<Prescricao>? Prescricoes { get; set; }
        public ICollection<Exame>? Exames { get; set; }

        public Internacao? Internacao { get; set; }
    }
}
