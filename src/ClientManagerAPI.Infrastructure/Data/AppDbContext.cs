using ClientManagerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ClientManagerAPI.Infrastructure.Configuration;

namespace ClientManagerAPI.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes => Set<Cliente>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
    }
}

