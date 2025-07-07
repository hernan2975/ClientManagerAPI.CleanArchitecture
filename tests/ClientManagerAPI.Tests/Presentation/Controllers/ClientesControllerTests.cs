
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ClientManagerAPI.Presentation.Controllers;
using ClientManagerAPI.Application.UseCases.CrearCliente;
using ClientManagerAPI.Application.DTOs;
using Moq;

public class ClientesControllerTests
{
    [Fact]
    public async Task Crear_Deberia_DevolverCreatedConId()
    {
        // Arrange
        var handlerMock = new Mock<CrearClienteHandler>();
        handlerMock.Setup(h => h.Handle(It.IsAny<ClienteDto>()))
                   .ReturnsAsync(Guid.NewGuid());

        var controller = new ClientesController(handlerMock.Object, Mock.Of<ActualizarClienteHandler>());
        var dto = new ClienteDto
        {
            Nombre = "Lucas",
            Email = "lucas@demo.com",
            Calle = "Calle Falsa",
            Ciudad = "Springfield",
            Provincia = "Buenos Aires"
        };

        // Act
        var result = await controller.Crear(dto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        createdResult.StatusCode.Should().Be(201);
    }
}
