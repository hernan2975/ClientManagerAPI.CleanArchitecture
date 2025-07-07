namespace ClientManagerAPI.Domain.ValueObjects;

public record Direccion(string Calle, string Ciudad, string Provincia)
{
    public string Formatear() => $"{Calle}, {Ciudad}, {Provincia}";
}

