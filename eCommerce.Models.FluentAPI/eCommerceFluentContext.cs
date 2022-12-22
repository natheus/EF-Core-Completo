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

            modelBuilder.Entity<Usuario>().HasIndex("CPF").IsUnique().HasFilter("[CPF] is not null").HasDatabaseName("IX_CPF_UNIQUE");
            modelBuilder.Entity<Usuario>().HasIndex(a => a.CPF);

            modelBuilder.Entity<Usuario>().HasIndex("CPF", "EMAIL");
            modelBuilder.Entity<Usuario>().HasIndex(a => new { a.CPF, a.Email });

            modelBuilder.Entity<Usuario>().HasKey("Id");
            modelBuilder.Entity<Usuario>().HasKey(a => a.Id);

            modelBuilder.Entity<Usuario>().HasKey("Id", "CPF");
            modelBuilder.Entity<Usuario>().HasKey(a => new { a.Id, a.CPF });

            modelBuilder.Entity<Usuario>().HasAlternateKey("CPF", "Email");
            modelBuilder.Entity<Usuario>().HasNoKey();


            modelBuilder.Entity<Usuario>().HasOne(u => u.Contato).WithOne(c => c.Usuario).HasForeignKey<Contato>(a => a.UsuarioId).OnDelete(DeleteBehavior.);
            modelBuilder.Entity<Usuario>().HasMany(u => u.EnderecosEntrega).WithOne(e => e.Usuario).HasForeignKey(e => e.UsuarioId);
            modelBuilder.Entity<Usuario>().HasMany(u => u.Departamentos).WithMany(d => d.Usuarios);
        }
    }
}
