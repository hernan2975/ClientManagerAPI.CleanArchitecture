
using Xunit;
using FluentAssertions;
using ClientManagerAPI.Application.UseCases.CrearCliente;
using ClientManagerAPI.Application.DTOs;
using ClientManagerAPI.Application.Services;
using ClientManagerAPI.Tests.Mocks;

public class CrearClienteHandlerTests
{
    [Fact]
    public async Task Handle_Deberia_CrearClienteYDevolverId()
    {
        var dto = new ClienteDto
        {
            Nombre = "Ana",
            Email = "ana@demo.com",
            Calle = "Calle 1",
            Ciudad = "Ciudad X",
            Provincia = "Provincia Y"
        };

        var unitOfWork = UnitOfWorkMock.Create();
        var service = new ClienteService();
        var handler = new CrearClienteHandler(unitOfWork.Object, service);

        var id = await handler.Handle(dto);

        id.Should().NotBeEmpty();
        unitOfWork.Verify(u => u.GuardarCambiosAsync(), Times.Once);
    }
}
