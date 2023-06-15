namespace UvEats_Aplicaciones.Models;
public  class UsuarioDominio
{
    public int IdUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Tipo { get; set; }

    public byte[]? Foto { get; set; }
}