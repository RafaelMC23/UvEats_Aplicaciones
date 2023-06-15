namespace UvEats_Aplicaciones.Business;
using UvEats_Aplicaciones.Business;
using UvEats_Aplicaciones.Models;
using System.Globalization;
using System.Text.Json;


public class LoginWSProvider : ILoginProvider {        
    HttpClient _client;

    public LoginWSProvider(IHttpClientFactory fcliente) 
    {
        _client = fcliente.CreateClient("Login/ValidarUsuarioLogin");                
    }
    
    
    public (int, UsuarioDominio,string) iniciarSesion(LoginSesion _credenciales)
    {
       var  credenciales = _credenciales;
       datosSesion ds = new  datosSesion();
        try {            
            var peticion = new PeticionLogin(){login = credenciales.correo, password=credenciales.contrasena};
            var response = _client.PostAsJsonAsync<PeticionLogin>($"", peticion);
            var respuestaHTTP = response.Result;
            var json = respuestaHTTP.Content.ReadAsStringAsync().Result;            
            var datos = JsonSerializer.Deserialize<(int,UsuarioDominio,string)>(json);
             
             ds.codigo = datos.Item1;
             ds.usuario = datos.Item2;
             ds.token = datos.Item3;
             return (ds.codigo,ds.usuario,ds.token);
        } catch (Exception e) {
          //  return null;
        }
        // return (ds.codigo,ds.usuario,ds.token);
    }
    

    class PeticionLogin {
        public String login {get; set;}
        public String password {get; set;}
    }


}
