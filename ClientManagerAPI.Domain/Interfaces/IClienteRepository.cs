using ClientManagerAPI.Domain.Entities;

namespace ClientManagerAPI.Domain.Interfaces;

public interface IClienteRepository
{
    Task<Cliente?> ObtenerPorIdAsync(Guid id);
    Task<List<Cliente>> ObtenerTodosAsync();
    Task AgregarAsync(Cliente cliente);
    Task ActualizarAsync(Cliente cliente);
    Task EliminarAsync(Guid id);
}

