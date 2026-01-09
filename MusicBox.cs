//using notas;
using listadoble;

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