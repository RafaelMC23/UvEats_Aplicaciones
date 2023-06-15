namespace UvEats_Aplicaciones.Models;

public class datosSesion
{
    public int codigo { get; set; }
    public UsuarioDominio usuario { get; set; }
    public string token { get; set; }
}