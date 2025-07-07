using ClientManagerAPI.Application.DTOs;
using ClientManagerAPI.Application.Interfaces;
using ClientManagerAPI.Domain.ValueObjects;

namespace ClientManagerAPI.Application.UseCases.ActualizarCliente;

public class ActualizarClienteHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public ActualizarClienteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(Guid clienteId, ClienteDto dto)
    {
        var cliente = await _unitOfWork.Clientes.ObtenerPorIdAsync(clienteId);
        if (cliente is null) return false;

        var nuevaDireccion = new Direccion(dto.Calle, dto.Ciudad, dto.Provincia);
        cliente.ActualizarDireccion(nuevaDireccion);

        await _unitOfWork.GuardarCambiosAsync();
        return true;
    }
}
