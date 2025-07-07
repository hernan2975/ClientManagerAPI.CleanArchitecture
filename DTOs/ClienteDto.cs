
namespace ClientManagerAPI.Application.DTOs;

public class ClienteDto
{
    public string Nombre { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Calle { get; set; } = default!;
    public string Ciudad { get; set; } = default!;
    public string Provincia { get; set; } = default!;
}
