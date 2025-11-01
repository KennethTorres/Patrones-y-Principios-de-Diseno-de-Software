public class CalculadoraArea
{
    public double CalcularArea(object figura)
    {
        if (figura is Circulo c)
            return Math.PI * c.Radio * c.Radio;

        if (figura is Cuadrado s)
            return s.Lado * s.Lado;

        return 0;
    }
}

public class Circulo { public double Radio { get; set; } }
public class Cuadrado { public double Lado { get; set; } }












public interface IFigura
{
    double CalcularArea();
}

public class Circulo : IFigura
{
    public double Radio { get; set; }
    public double CalcularArea() => Math.PI * Radio * Radio;
}

public class Cuadrado : IFigura
{
    public double Lado { get; set; }
    public double CalcularArea() => Lado * Lado;
}

public class CalculadoraArea
{
    public double CalcularArea(IFigura figura)
    {
        return figura.CalcularArea();
    }
}