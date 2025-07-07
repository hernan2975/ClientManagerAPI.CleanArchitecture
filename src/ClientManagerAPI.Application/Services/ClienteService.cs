using ClientManagerAPI.Application.DTOs;
using ClientManagerAPI.Domain.Entities;
using ClientManagerAPI.Domain.ValueObjects;

namespace ClientManagerAPI.Application.Services;

public class ClienteService
{
    public Cliente CrearDesdeDto(ClienteDto dto)
    {
        var direccion = new Direccion(dto.Calle, dto.Ciudad, dto.Provincia);
        return new Cliente(dto.Nombre, dto.Email, direccion);
    }
}
