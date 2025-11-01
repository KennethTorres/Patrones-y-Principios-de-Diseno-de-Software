
// FORMA INCORRECTA - ISP
// Una sola interfaz con todos los métodos, obligando a todas las aves a implementarlos

interface IAve
{
    void Comer();
    int Volar();   
    void Correr();
    void Nadar();
}


class Tucan : IAve
{
    public void Comer() { }
    
    public int Volar() 
    { 

    }
    
    public void Correr() 
    { 
        throw new NotImplementedException("Los tucanes no corren");
    }
    
    public void Nadar() 
    { 
        throw new NotImplementedException("Los tucanes no nadan");
    }
}

class Colibri : IAve
{
    public void Comer() { }
    
    public int Volar() 
    { 

    }
    

    public void Correr() 
    { 
        throw new NotImplementedException("Los colibríes no corren");
    }
    
    public void Nadar() 
    { 
        throw new NotImplementedException("Los colibríes no nadan");
    }
}







// FORMA CORRECTA - ISP
 // Interfaces segregadas para cada tipo de ave




interface IAve
{
    void Comer();
}

interface IAveVoladora
{
    int Volar();
}


interface IAveCorredor
{
    void Correr();
}


interface IAveNadadora
{
    void Nadar();
}



class Tucan : IAve, IAveVoladora
{
    public int Volar() 
    { 
        return 100; 
    }
    
    public void Comer() 
    { 
    }
}


class Colibri : IAve, IAveVoladora
{
    public int Volar() 
    { 
        return 200; 
    }
    
    public void Comer() 
    { 
    }
}


class Avestruz : IAve, IAveCorredor
{
    public void Comer() 
    { 
    }
    
    public void Correr() 
    { 
    }
}


class Pinguino : IAve, IAveNadadora
{
    public void Comer() 
    { 
    }
    
    public void Nadar() 
    { 
    }
}