using System;
using notas;
using MusicBox.core;

namespace MusicBox.Tests
{
    public class PruebasSimples
    {
        public static void Main(string[] args)
        {
            int pasadas = 0;
            int falladas = 0;

            if (Test_ObtenerFrecuencia()) pasadas++; else falladas++;
            if (Test_ObtenerMs()) pasadas++; else falladas++;
            if (Test_CambiarTempo()) pasadas++; else falladas++;
            if (Test_Insertar_Partitura()) pasadas++; else falladas++;
            if (Test_Reproducir_Partitura()) pasadas++; else falladas++;
            if (Test_Reproducir_Partitura_Alreves()) pasadas++; else falladas++;
            if (Test_Nodo_Constructor()) pasadas++; else falladas++;
            if (Test_ObtenerFrecuencia_Excepcion()) pasadas++; else falladas++;
            if (Test_ObtenerMs_Excepcion()) pasadas++; else falladas++;
            if (Test_CambiarTempo_Excepcion()) pasadas++; else falladas++;

            Console.WriteLine($"Pruebas pasadas: {pasadas}/10");
            Console.WriteLine($"Pruebas falladas: {falladas}/10");
        }

        static bool Test_ObtenerFrecuencia()
        {
            var reproductor = new ReproductorMusical();
            int esperadoDO = 262;
            int esperadoLA = 440;
            int esperadoMI = 330;
            
            //MAYUSCULA
            int resultadoDO = reproductor.ObtenerFrecuencia("DO");
            //minuscula
            int resultadoLA = reproductor.ObtenerFrecuencia("la"); 
            //Mixto
            int resultadoMI = reproductor.ObtenerFrecuencia("Mi"); 
            
            if (resultadoDO == esperadoDO && resultadoLA == esperadoLA && resultadoMI == esperadoMI)
            {
                Console.WriteLine("TestOtenerFrecuencia: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"TestObtenerFrecuencia: Fallo");
                return false;
            }
        }

        static bool Test_ObtenerMs()
        {
            var reproductor = new ReproductorMusical();
            int esperadoNegra = 1000;
            int esperadoBlanca = 2000;
            int esperadoCorchea = 500;

            //MAYUSUCULA
            int resultadoNegra = reproductor.ObtenerMs("negra");
            //minuscula
            int resultadoBlanca = reproductor.ObtenerMs("BLANCA"); 
            //Mixta
            int resultadoCorchea = reproductor.ObtenerMs("Corchea"); 
            
            if (resultadoNegra == esperadoNegra && resultadoBlanca == esperadoBlanca && resultadoCorchea == esperadoCorchea)
            {
                Console.WriteLine("TestObtenerMs: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"Test_ObtenerMs: Fallo");
                return false;
            }
        }

        static bool Test_CambiarTempo()
        {
            var reproductor = new ReproductorMusical();
            reproductor.CambiarTempo(2.0);
            int esperadoNegra = 2000;
            int esperadoBlanca = 4000;
            int esperadoRedonda = 8000;
            int resultadoNegra = reproductor.ObtenerMs("negra");
            int resultadoBlanca = reproductor.ObtenerMs("blanca");
            int resultadoRedonda = reproductor.ObtenerMs("redonda");
            
            if (resultadoNegra == esperadoNegra && resultadoBlanca == esperadoBlanca && resultadoRedonda == esperadoRedonda)
            {
                Console.WriteLine("TestCambiarTempo: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"TestCambiarTempo: Fallo");
                return false;
            }
        }

        static bool Test_Insertar_Partitura()
        {
            var lista = new Lista_Doble_MusicBox();
            lista.insertar_partitura(("DO", "negra"));
            lista.insertar_partitura(("RE", "corchea"));
            lista.insertar_partitura(("MI", "blanca"));
            var (notaCabeza, figuraCabeza) = lista.cabeza!.getDato();
            var (notaViejo, figuraViejo) = lista.nodo_viejo!.getDato();
            bool esperado = true;
            bool resultado = (notaCabeza == "DO" && figuraCabeza == "negra" && notaViejo == "MI" && figuraViejo == "blanca");
            
            if (resultado == esperado)
            {
                Console.WriteLine("TestInsertarPartitura: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"TestInsertarPartitura: Fallo");
                return false;
            }
        }

        static bool Test_Reproducir_Partitura()
        {
            var lista = new Lista_Doble_MusicBox();
            lista.insertar_partitura(("DO", "corchea"));
            lista.insertar_partitura(("RE", "corchea"));
            lista.insertar_partitura(("MI", "corchea"));
            Nodo? actual = lista.cabeza;
            var (nota1, _) = actual!.getDato();
            actual = actual.siguiente;
            var (nota2, _) = actual!.getDato();
            actual = actual.siguiente;
            var (nota3, _) = actual!.getDato();
            
            bool esperado = true;
            bool resultado = (nota1 == "DO" && nota2 == "RE" && nota3 == "MI");
            
            if (resultado == esperado)
            {
                Console.WriteLine("Test_Reproducir_Partitura: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"Test_Reproducir_Partitura: Fallo");
                return false;
            }
        }

        static bool Test_Reproducir_Partitura_Alreves()
        {
            var lista = new Lista_Doble_MusicBox();
            lista.insertar_partitura(("DO", "corchea"));
            lista.insertar_partitura(("RE", "corchea"));
            lista.insertar_partitura(("MI", "corchea"));
            
            Nodo? actual = lista.nodo_viejo;
            var (nota1, _) = actual!.getDato();
            actual = actual.anterior;
            var (nota2, _) = actual!.getDato();
            actual = actual.anterior;
            var (nota3, _) = actual!.getDato();
            
            bool esperado = true;
            bool resultado = (nota1 == "MI" && nota2 == "RE" && nota3 == "DO");
            
            if (resultado == esperado)
            {
                Console.WriteLine("Test_Reproducir_Partitura_Alreves: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"Test_Reproducir_Partitura_Alreves: Fallo");
                return false;
            }
        }

        static bool Test_Nodo_Constructor()
        {
            var nodo = new Nodo("LA", "blanca");
            var (nota, figura) = nodo.getDato();
            
            bool esperadoSiguiente = true; 
            bool esperadoAnterior = true; 
            bool esperadoDatos = true; 
            
            bool resultadoSiguiente = (nodo.siguiente == null);
            bool resultadoAnterior = (nodo.anterior == null);
            bool resultadoDatos = (nota == "LA" && figura == "blanca");
            
            if (resultadoSiguiente == esperadoSiguiente && 
                resultadoAnterior == esperadoAnterior && 
                resultadoDatos == esperadoDatos)
            {
                Console.WriteLine("Test_Nodo_Constructor: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"Test_Nodo_Constructor: Fallo");
                return false;
            }
        }


        //-----------------TEST PARA VERFICAR QUE LOS METODOS NO CRASHEEN Y MANEJEN BIEN LOS ERRORES----------------------
    


    static bool Test_ObtenerFrecuencia_Excepcion()
        {
            var reproductor = new ReproductorMusical();
            bool esperado = true;
            bool resultado = false;
            
            try
            {
                reproductor.ObtenerFrecuencia("XYZ"); 
                resultado = false;
            }
            catch (Exception)
            {
                resultado = true; 
            }
            
            if (resultado == esperado)
            {
                Console.WriteLine("Test_ObtenerFrecuencia_Excepcion: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"Test_ObtenerFrecuencia_Excepcion: Fallo");
                return false;
            }
        }

        static bool Test_ObtenerMs_Excepcion()
        {
            var reproductor = new ReproductorMusical();
            bool esperado = true;
            bool resultado = false;
            
            try
            {
                reproductor.ObtenerMs("invalida"); 
                resultado = false;
            }
            catch (Exception)
            {
                resultado = true;
            }
            
            if (resultado == esperado)
            {
                Console.WriteLine("Test_ObtenerMs_Excepcion: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"Test_ObtenerMs_Excepcion: Fallo");
                return false;
            }
        }

        static bool Test_CambiarTempo_Excepcion()
        {
            var reproductor = new ReproductorMusical();
            bool esperado = true;
            bool resultado = false;
            
            try
            {
                reproductor.CambiarTempo(10.0); 
                resultado = false; 
            }
            catch (Exception)
            {
                resultado = true; 
            }
            
            if (resultado == esperado)
            {
                Console.WriteLine("Test_CambiarTempo_Excepcion: Paso");
                return true;
            }
            else
            {
                Console.WriteLine($"Test_CambiarTempo_Excepcion: Fallo");
                return false;
            }
        }
    }
}