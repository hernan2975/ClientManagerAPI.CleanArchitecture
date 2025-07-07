
using Moq;
using ClientManagerAPI.Application.Interfaces;
using ClientManagerAPI.Domain.Interfaces;

namespace ClientManagerAPI.Tests.Mocks;

public static class UnitOfWorkMock
{
    public static Mock<IUnitOfWork> Create()
    {
        var repoMock = new Mock<IClienteRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        unitOfWorkMock.Setup(u => u.Clientes).Returns(repoMock.Object);
        unitOfWorkMock.Setup(u => u.GuardarCambiosAsync()).ReturnsAsync(1);

        return unitOfWorkMock;
    }
}
