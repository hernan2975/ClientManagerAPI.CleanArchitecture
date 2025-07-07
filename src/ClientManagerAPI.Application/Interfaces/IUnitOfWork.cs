using ClientManagerAPI.Domain.Interfaces;

namespace ClientManagerAPI.Application.Interfaces;

public interface IUnitOfWork
{
    IClienteRepository Clientes { get; }
    Task<int> GuardarCambiosAsync();
}
