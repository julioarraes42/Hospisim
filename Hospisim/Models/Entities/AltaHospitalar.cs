using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPISIM.Models
{
    public class AltaHospitalar
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string CondicaoPaciente { get; set; }
        public string InstrucoesPosAlta { get; set; }

        [ForeignKey("Internacao")]
        public Guid InternacaoId { get; set; }

    }
}
