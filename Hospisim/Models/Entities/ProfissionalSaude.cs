﻿using Hospisim.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class ProfissionalSaude
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string RegistroConselho { get; set; }
        public string TipoRegistro { get; set; }

        [ForeignKey("Especialidade")]
        public Guid? EspecialidadeId { get; set; }

        public DateTime DataAdmissao { get; set; }
        public int CargaHorariaSemanal { get; set; }
        public string Turno { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Atendimento> Atendimentos { get; set; }


    }
}
