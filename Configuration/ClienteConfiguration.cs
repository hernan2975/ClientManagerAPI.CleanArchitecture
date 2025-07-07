using ClientManagerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagerAPI.Infrastructure.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(c => c.Direccion, dir =>
        {
            dir.Property(d => d.Calle).HasColumnName("Calle").HasMaxLength(100);
            dir.Property(d => d.Ciudad).HasColumnName("Ciudad").HasMaxLength(50);
            dir.Property(d => d.Provincia).HasColumnName("Provincia").HasMaxLength(50);
        });
    }
}

