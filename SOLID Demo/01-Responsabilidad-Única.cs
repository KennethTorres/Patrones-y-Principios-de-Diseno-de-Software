//  FORMA INCORRECTA - SRP
// Una clase que hace DEMASIADAS cosas

class Usuario
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Contraseña { get; set; }


    public bool ValidarEmail()
    {
        return Email.Contains("@");
    }

  
    public void GuardarEnBaseDeDatos()
    {
        Console.WriteLine("Conectando a la base de datos...");
        Console.WriteLine($"Guardando usuario {Nombre} en la BD");
    }

 
    public void EnviarEmailBienvenida()
    {
        Console.WriteLine("Conectando al servidor de email...");
        Console.WriteLine($"Enviando email de bienvenida a {Email}");

    }


    public void GenerarReportePDF()
    {
        Console.WriteLine("Generando PDF...");
        Console.WriteLine($"Reporte del usuario: {Nombre}");
    }
}






//  FORMA CORRECTA - SRP
// Cada clase tiene UNA sola responsabilidad


class Usuario
{
    public string Nombre { get; set; }
    public string Email { get; set; }
    public string Contraseña { get; set; }
}


class ValidadorUsuario
{
    public bool ValidarEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public bool ValidarContraseña(string contraseña)
    {
        return contraseña.Length >= 8;
    }
}


class RepositorioUsuario
{
    public void Guardar(Usuario usuario)
    {
        Console.WriteLine("Conectando a la base de datos...");
        Console.WriteLine($"Guardando usuario {usuario.Nombre} en la BD");
    }

    public Usuario ObtenerPorEmail(string email)
    {
        Console.WriteLine($"Buscando usuario con email {email}");
        return new Usuario();
    }
}


class ServicioEmail
{
    public void EnviarBienvenida(Usuario usuario)
    {
        Console.WriteLine("Conectando al servidor de email...");
        Console.WriteLine($"Enviando email de bienvenida a {usuario.Email}");
    }

    public void EnviarRecuperacionContraseña(Usuario usuario)
    {
        Console.WriteLine($"Enviando email de recuperación a {usuario.Email}");
    }
}


class GeneradorReportes
{
    public void GenerarPDFUsuario(Usuario usuario)
    {
        Console.WriteLine("Generando PDF...");
        Console.WriteLine($"Reporte del usuario: {usuario.Nombre}");
    }
}


class Program
{
    static void Main()
    {
        // Crear usuario
        Usuario nuevoUsuario = new Usuario 
        { 
            Nombre = "Juan Pérez", 
            Email = "juan@email.com",
            Contraseña = "MiContraseña123"
        };

        // Validar
        ValidadorUsuario validador = new ValidadorUsuario();
        if (validador.ValidarEmail(nuevoUsuario.Email))
        {
            // Guardar
            RepositorioUsuario repositorio = new RepositorioUsuario();
            repositorio.Guardar(nuevoUsuario);

            // Enviar email
            ServicioEmail servicioEmail = new ServicioEmail();
            servicioEmail.EnviarBienvenida(nuevoUsuario);

            // Generar reporte
            GeneradorReportes generador = new GeneradorReportes();
            generador.GenerarPDFUsuario(nuevoUsuario);
        }
    }
}