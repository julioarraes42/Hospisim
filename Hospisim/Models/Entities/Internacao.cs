﻿using Hospisim.Models.Entities;
using HOSPISIM.Models;
using System.ComponentModel.DataAnnotations.Schema;


public class Internacao
{
    public Guid Id { get; set; }

    [ForeignKey("Paciente")]
    public Guid PacienteId { get; set; }


    [ForeignKey("Atendimento")]
    public Guid AtendimentoId { get; set; }               


    public DateTime DataEntrada { get; set; }
    public DateTime? PrevisaoAlta { get; set; }
    public string MotivoInternacao { get; set; }
    public string Leito { get; set; }
    public string Quarto { get; set; }
    public string Setor { get; set; }
    public string? PlanoSaudeUtilizado { get; set; }
    public string ObservacoesClinicas { get; set; }
    public string StatusInternacao { get; set; }

    public AltaHospitalar? AltaHospitalar { get; set; }
}
