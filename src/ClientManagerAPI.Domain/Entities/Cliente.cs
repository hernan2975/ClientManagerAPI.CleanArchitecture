
namespace ClientManagerAPI.Domain.Entities;

public class Cliente : BaseEntity
{
    public string Nombre { get; private set; }
    public string Email { get; private set; }
    public Direccion Direccion { get; private set; }

    // Constructor protegido para EF
    protected Cliente() { }

    public Cliente(string nombre, string email, Direccion direccion)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
        if (!email.Contains("@")) throw new ArgumentException("Email inválido.");

        Nombre = nombre;
        Email = email;
        Direccion = direccion;
        CreatedAt = DateTime.UtcNow;
    }

    public void ActualizarDireccion(Direccion nuevaDireccion)
    {
        Direccion = nuevaDireccion;
        UpdatedAt = DateTime.UtcNow;
    }
}
