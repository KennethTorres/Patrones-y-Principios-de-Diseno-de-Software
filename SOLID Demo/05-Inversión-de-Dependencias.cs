// FORMA INCORRECTA - DIP
// Las clases de alto nivel dependen directamente de clases de bajo nivel

// Clases de bajo nivel
class MySQLBaseDeDatos
{
    public void Guardar(string datos)
    {
        Console.WriteLine($"Guardando en MySQL: {datos}");
    }
}

class SQLServerBaseDeDatos
{
    public void Insertar(string datos)
    {
        Console.WriteLine($"Insertando en SQL Server: {datos}");
    }
}

//  Clase de alto nivel depende directamente de MySQL
class ServicioUsuario
{
    private MySQLBaseDeDatos baseDatos;

    public ServicioUsuario()
    {
        //  Dependencia directa de una clase
        baseDatos = new MySQLBaseDeDatos();
    }

    public void RegistrarUsuario(string nombre)
    {
        Console.WriteLine($"Registrando usuario: {nombre}");
        baseDatos.Guardar(nombre);
    }
}


// FORMA CORRECTA - Aplicando DIP
// Ambas clases dependen de abstracciones (interfaces)


interface IBaseDeDatos
{
    void Guardar(string datos);
}

// Implementaciones concretas (bajo nivel) que dependen de la abstracción
class MySQLBaseDeDatos : IBaseDeDatos
{
    public void Guardar(string datos)
    {
        Console.WriteLine($" Guardando en MySQL: {datos}");
    }
}

class SQLServerBaseDeDatos : IBaseDeDatos
{
    public void Guardar(string datos)
    {
        Console.WriteLine($" Guardando en SQL Server: {datos}");
    }
}

class MongoDBBaseDeDatos : IBaseDeDatos
{
    public void Guardar(string datos)
    {
        Console.WriteLine($" Guardando en MongoDB: {datos}");
    }
}

// Clase de alto nivel que también depende de la abstracción
class ServicioUsuario
{
    private IBaseDeDatos baseDatos;

    //  Inyección de dependencias
    public ServicioUsuario(IBaseDeDatos baseDatos)
    {
        this.baseDatos = baseDatos;
    }

    public void RegistrarUsuario(string nombre)
    {
        Console.WriteLine($"Registrando usuario: {nombre}");
        baseDatos.Guardar(nombre);
    }
}

// USO - Ahora es flexible y fácil de cambiar
class Program
{
    static void Main()
    {
        Console.WriteLine("Ejemplo con MySQL");
        IBaseDeDatos mysqlDB = new MySQLBaseDeDatos();
        ServicioUsuario servicio1 = new ServicioUsuario(mysqlDB);
        servicio1.RegistrarUsuario("Juan Pérez");

        Console.WriteLine("Cambio a SQL Server");
        IBaseDeDatos sqlServerDB = new SQLServerBaseDeDatos();
        ServicioUsuario servicio2 = new ServicioUsuario(sqlServerDB);
        servicio2.RegistrarUsuario("María García");

        Console.WriteLine("Cambio a MongoDB");
        IBaseDeDatos mongoDB = new MongoDBBaseDeDatos();
        ServicioUsuario servicio3 = new ServicioUsuario(mongoDB);
        servicio3.RegistrarUsuario("Carlos López");
    }
}