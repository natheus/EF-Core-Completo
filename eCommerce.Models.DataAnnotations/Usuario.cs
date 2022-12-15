using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    [Index(nameof(Email), IsUnique = true, Name = "IX_EMAIL_UNICO")]
    [Index(nameof(Nome), nameof(CPF))]
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /*
        [Key]
        [Column("COD")]
        */
        public int Codigo { get; set; }
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string? Sexo { get; set; }

        [Column("REGISTRO_GERAL")]
        public string? RG { get; set; }
        public string CPF { get; set; } = null!;
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? SituacaoCadastro { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Matricula { get; set; }
        /*
         * Software/Aplicativo - Não persistido.
         * RegistroAtivo = (SituacaoCadastro == "Ativo") ? true : false;
         */
        [NotMapped]
        public bool RegistroAtivo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset DataCadastro { get; set; } // getdate()

        [ForeignKey("UsuarioId")]
        public Contato? Contato { get; set; }
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }

        [InverseProperty("Cliente")]
        public ICollection<Pedido>? PedidosCompradosPeloCliente { get; set; }

        [InverseProperty("Colaborador")]
        public ICollection<Pedido>? PedidosGerenciadosPeloColaborador { get; set; }

        [InverseProperty("Supervisor")]
        public ICollection<Pedido>? PedidosSupervisionadosPeloColaboradorSupervisor { get; set; }
    }
}
