namespace eCommerce.Office.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public ICollection<Veiculo>? Veiculos { get; set; }
        public ICollection<ColaboradorSetor> ColaboradoresSetores { get; set; } = null!;
        public ICollection<Turma>? Turmas { get; set; }
    }
}
