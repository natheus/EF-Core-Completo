using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Models.Exercicio.Configuration
{
    public class EnderecoEntregaConfiguration : IEntityTypeConfiguration<EnderecoEntrega>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntrega> builder)
        {
            builder.Property(u => u.CEP).HasMaxLength(8);
        }
    }
}
