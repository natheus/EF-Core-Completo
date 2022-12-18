using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceFluentContext : DbContext
    {
        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        { 

        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().Property(a => a.RG).HasColumnName("REGISTRO_GERAL").HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Ignore(a => a.Sexo);
            modelBuilder.Entity<Usuario>().Property(a => a.Id).ValueGeneratedOnAdd();
        }
    }
}
