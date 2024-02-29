namespace SalaoDeBeleza.Model
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeStatus { get; set; }
        public int StatusId { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public string Servicos { get; set; }
        public decimal ValorDefinido { get; set; }
        public string DataCadastro { get; set; }
        public string DataAgendada { get; set; }
        public string nomeServico { get; set; }
    }
}
