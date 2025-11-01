public class Ave
{
    public virtual void Volar()
    {
        Console.WriteLine("El ave está volando");
    }
}

public class Pinguino : Ave
{
    public override void Volar()
    {
        throw new Exception("Los pingüinos no pueden volar");
    }
}











public abstract class Ave
{
    public abstract void Mostrar();
}

public abstract class AveVoladora : Ave
{
    public abstract void Volar();
}

public class Gorrion : AveVoladora
{
    public override void Mostrar() => Console.WriteLine("Soy un gorrión");
    public override void Volar() => Console.WriteLine("El gorrión vuela");
}

public class Pinguino : Ave
{
    public override void Mostrar() => Console.WriteLine("Soy un pingüino, no vuelo");
}