using ClientManagerAPI.Application.DTOs;
using ClientManagerAPI.Application.Interfaces;
using ClientManagerAPI.Application.Services;

namespace ClientManagerAPI.Application.UseCases.CrearCliente;

public class CrearClienteHandler
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ClienteService _clienteService;

    public CrearClienteHandler(IUnitOfWork unitOfWork, ClienteService clienteService)
    {
        _unitOfWork = unitOfWork;
        _clienteService = clienteService;
    }

    public async Task<Guid> Handle(ClienteDto dto)
    {
        var cliente = _clienteService.CrearDesdeDto(dto);
        await _unitOfWork.Clientes.AgregarAsync(cliente);
        await _unitOfWork.GuardarCambiosAsync();
        return cliente.Id;
    }
}
