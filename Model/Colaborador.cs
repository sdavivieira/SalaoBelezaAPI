namespace SalaoDeBeleza.Model
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string? Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
