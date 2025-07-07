
using ClientManagerAPI.Domain.Entities;
using ClientManagerAPI.Domain.Interfaces;
using Moq;

namespace ClientManagerAPI.Tests.Mocks;

public static class ClienteRepositoryMock
{
    public static Mock<IClienteRepository> Create()
    {
        var repo = new Mock<IClienteRepository>();

        var clienteEjemplo = new Cliente(
            "Ejemplo",
            "ejemplo@correo.com",
            new Domain.ValueObjects.Direccion("Calle Falsa", "Guatraché", "La Pampa")
        );

        repo.Setup(r => r.ObtenerPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(clienteEjemplo);

        repo.Setup(r => r.ObtenerTodosAsync())
            .ReturnsAsync(new List<Cliente> { clienteEjemplo });

        repo.Setup(r => r.AgregarAsync(It.IsAny<Cliente>()))
            .Returns(Task.CompletedTask);

        repo.Setup(r => r.ActualizarAsync(It.IsAny<Cliente>()))
            .Returns(Task.CompletedTask);

        repo.Setup(r => r.EliminarAsync(It.IsAny<Guid>()))
            .Returns(Task.CompletedTask);

        return repo;
    }
}
