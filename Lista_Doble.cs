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
    public Nodo(String nota, String figura)
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
    public Nodo? valor_nodo;
    
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
       

    }

}

class Programa
{
    static void Main(string[] args)
    {
        
    }
}