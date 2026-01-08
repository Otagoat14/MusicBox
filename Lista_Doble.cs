using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Security;
using System.Diagnostics.CodeAnalysis;

//Clase Nodo
public class Nodo
{
    public (string nota, string figura) partitura;
    public Nodo? siguiente;
    public Nodo? anterior;
    

    //Constructor
    public Nodo(string nota, string figura)
    {
        partitura = (nota, figura);
        siguiente = null;
        anterior = null;
    }
}


//Clae para controlar la lista
public class Lista_Doble_MusicBox
{
    public Nodo? cabeza;
    public Nodo? nodo_viejo;
    
    
    public Lista_Doble_MusicBox()
    {
        cabeza = null;
        nodo_viejo = null;
    }

    public void insertar_partituras((string nota, string figura) partitura)
    {
        Nodo nuevo_nodo = new Nodo(partitura.nota, partitura.figura);

        if (cabeza == null)
        {
            cabeza = nuevo_nodo;
            nuevo_nodo.siguiente = null;
            nuevo_nodo.anterior = null;
            nodo_viejo = nuevo_nodo;
        }
        
        else 
        {
            nodo_viejo.siguiente = nuevo_nodo;
            nuevo_nodo.siguiente = null;
            nuevo_nodo.anterior = nodo_viejo;
            nodo_viejo = nuevo_nodo;
        }
    }

    public void reproducir_partitura()
    {
        Nodo? cabeza_2 = cabeza;

        while(cabeza_2 != null)
        {
            Console.WriteLine($"Nota: {cabeza_2.partitura.nota}, Figura: {cabeza_2.partitura.figura}");
            cabeza_2 = cabeza_2.siguiente;
        }
    }

    public void reproducir_partitura_alreves()
    {
        Nodo? cabeza_2 = nodo_viejo;

        while(cabeza_2 != null)
        {
            Console.WriteLine($"Nota: {cabeza_2.partitura.nota}, Figura: {cabeza_2.partitura.figura}");
            cabeza_2 = cabeza_2.anterior;
        }
    }

}

class Programa
{
    static void Main(string[] args)
    {
        Lista_Doble_MusicBox lista = new Lista_Doble_MusicBox();
        lista.insertar_partituras(("Do", "Negra"));
        lista.insertar_partituras(("Re", "Semi"));
        lista.insertar_partituras(("Fa", "Corchea"));
        lista.insertar_partituras(("Mi", "Blanca"));
        lista.insertar_partituras(("Do", "Redonda"));
        lista.insertar_partituras(("La", "Negra"));

        lista.reproducir_partitura();
        Console.WriteLine("**********************************");
        Console.WriteLine("************Lista al reves**************");
        lista.reproducir_partitura_alreves();

    }
}