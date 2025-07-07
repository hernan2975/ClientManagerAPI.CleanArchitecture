using ClientManagerAPI.Domain.Entities;
using ClientManagerAPI.Domain.Interfaces;
using ClientManagerAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientManagerAPI.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> ObtenerPorIdAsync(Guid id) =>
        await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<List<Cliente>> ObtenerTodosAsync() =>
        await _context.Clientes.ToListAsync();

    public async Task AgregarAsync(Cliente cliente) =>
        await _context.Clientes.AddAsync(cliente);

    public async Task ActualizarAsync(Cliente cliente) =>
        _context.Clientes.Update(cliente);

    public async Task EliminarAsync(Guid id)
    {
        var cliente = await ObtenerPorIdAsync(id);
        if (cliente != null)
            _context.Clientes.Remove(cliente);
    }
}
