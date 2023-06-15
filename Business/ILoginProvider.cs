namespace UvEats_Aplicaciones.Business;
using UvEats_Aplicaciones.Models;


public interface ILoginProvider{
    public (int,UsuarioDominio,string) iniciarSesion ( LoginSesion _credenciales);
}