using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using CursosUI.Business;
using UvEats_Aplicaciones.Models;
using UvEats_Aplicaciones.Business;

namespace UvEats_Aplicaciones.Pages;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;
    public   ILoginProvider _login {get; set;}

    [BindProperty]
    public String txt_passwd {get; set;}

    [BindProperty]
    public String txt_correo {get; set;}

    public LoginModel(ILoginProvider login)
    {
       
        _login = login;        
    }

    public void OnGet()
    {

    }    
    

    public void OnPostLogin()
    {        
        if (_login != null && !String.IsNullOrEmpty(txt_correo) && !String.IsNullOrEmpty(txt_passwd)) {
            LoginSesion datos = new LoginSesion();
            datos.correo = txt_correo;
            datos.contrasena = txt_passwd;
            var datosSesion = _login.iniciarSesion(datos);
            if (datosSesion.Item1 != null && datosSesion.Item2 != null && datosSesion.Item3 != null) {
            
                Request.HttpContext.Session.SetString("usuario", datosSesion.Item2.ToString());
                Request.HttpContext.Session.SetString("token", datosSesion.Item3);
                Console.WriteLine("pasoooo");
               // Response.Redirect("CursosCard");
            }
            
        
        }

    }
}