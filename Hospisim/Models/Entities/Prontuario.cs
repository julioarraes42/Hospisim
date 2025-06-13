using HOSPISIM.Models;

namespace Hospisim.Models.Entities
{
    public class Prontuario
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataAbertura { get; set; }
        public string ObservacoesGerais { get; set; }

        public ICollection<Atendimento> Atendimentos { get; set; }
    }
}