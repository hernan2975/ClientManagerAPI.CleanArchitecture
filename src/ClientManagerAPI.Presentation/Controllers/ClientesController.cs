using Microsoft.AspNetCore.Mvc;
using ClientManagerAPI.Application.UseCases.CrearCliente;
using ClientManagerAPI.Application.UseCases.ActualizarCliente;
using ClientManagerAPI.Application.DTOs;

namespace ClientManagerAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly CrearClienteHandler _crearHandler;
    private readonly ActualizarClienteHandler _actualizarHandler;

    public ClientesController(
        CrearClienteHandler crearHandler,
        ActualizarClienteHandler actualizarHandler)
    {
        _crearHandler = crearHandler;
        _actualizarHandler = actualizarHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] ClienteDto dto)
    {
        var id = await _crearHandler.Handle(dto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id }, new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Actualizar(Guid id, [FromBody] ClienteDto dto)
    {
        var actualizado = await _actualizarHandler.Handle(id, dto);
        return actualizado ? NoContent() : NotFound();
    }

    [HttpGet("{id:guid}")]
    public IActionResult ObtenerPorId(Guid id)
    {
        // ⚠️ Implementar recuperación real con handler
        return Ok(new { id, nombre = "Simulado", email = "ejemplo@demo.com" });
    }
}
