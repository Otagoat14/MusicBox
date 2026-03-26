using System;
using notas;
using MusicBox.core;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MusicBox.Tests
{
    [MemoryDiagnoser]
    [SimpleJob(iterationCount: 50)]
    public class MusicBoxBenchmarks
    {
        [Benchmark]
        public void Benchmark_Insertar_100_Notas()
        {
            var lista = new Lista_Doble_MusicBox();
            for (int i = 0; i < 100; i++)
                lista.insertar_partitura(("Mi", "corchea"));
        }

        [Benchmark]
        public void Benchmark_Insertar_1000_Notas()
        {
            var lista = new Lista_Doble_MusicBox();
            for (int i = 0; i < 1000; i++)
                lista.insertar_partitura(("Sol", "negra"));
        }

        [Benchmark]
        public void Benchmark_Insertar_10000_Notas()
        {
            var lista = new Lista_Doble_MusicBox();
            for (int i = 0; i < 10000; i++)
                lista.insertar_partitura(("La", "negra"));
        }

        [Benchmark]
        public void Benchmark_ObtenerFrecuencia()
        {
            var reproductor = new ReproductorMusical();
            reproductor.ObtenerFrecuencia("Mi");
        }

        [Benchmark]
        public void Benchmark_ObtenerMs()
        {
            var reproductor = new ReproductorMusical();
            reproductor.ObtenerMs("corchea");
        }
    }

    public class PruebasSimples
    {
        // ── Cambia entre estos dos Main según lo que necesites ──

        // MAIN PARA MONITOREO (dotnet-counters / dotnet-trace)
        public static void Main(string[] args)
        {
            Console.WriteLine("Corriendo... presiona Ctrl+C para detener");
            while (true)
            {
                var lista = new Lista_Doble_MusicBox();
                for (int i = 0; i < 10000; i++)
                    lista.insertar_partitura(("La", "negra"));
                var rep = new ReproductorMusical();
                rep.ObtenerFrecuencia("Mi");
                rep.ObtenerMs("corchea");
            }
        }

        // MAIN PARA TESTS Y BENCHMARKS — descomenta cuando termines el monitoreo
        /*
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "benchmark")
            {
                BenchmarkDotNet.Running.BenchmarkRunner.Run<MusicBoxBenchmarks>();
                return;
            }

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

            Console.WriteLine($"\nPruebas pasadas: {pasadas}/10");
            Console.WriteLine($"Pruebas falladas: {falladas}/10");
        }
        */

        static bool Test_ObtenerFrecuencia()
        {
            var reproductor = new ReproductorMusical();
            int esperadoDO = 262;
            int esperadoLA = 440;
            int esperadoMI = 330;
            int resultadoDO = reproductor.ObtenerFrecuencia("DO");
            int resultadoLA = reproductor.ObtenerFrecuencia("la");
            int resultadoMI = reproductor.ObtenerFrecuencia("Mi");
            if (resultadoDO == esperadoDO && resultadoLA == esperadoLA && resultadoMI == esperadoMI)
            {
                Console.WriteLine("Test_ObtenerFrecuencia: Paso");
                return true;
            }
            else
            {
                Console.WriteLine("Test_ObtenerFrecuencia: Fallo");
                return false;
            }
        }

        static bool Test_ObtenerMs()
        {
            var reproductor = new ReproductorMusical();
            int esperadoNegra = 1000;
            int esperadoBlanca = 2000;
            int esperadoCorchea = 500;
            int resultadoNegra = reproductor.ObtenerMs("negra");
            int resultadoBlanca = reproductor.ObtenerMs("BLANCA");
            int resultadoCorchea = reproductor.ObtenerMs("Corchea");
            if (resultadoNegra == esperadoNegra && resultadoBlanca == esperadoBlanca && resultadoCorchea == esperadoCorchea)
            {
                Console.WriteLine("Test_ObtenerMs: Paso");
                return true;
            }
            else
            {
                Console.WriteLine("Test_ObtenerMs: Fallo");
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
                Console.WriteLine("Test_CambiarTempo: Paso");
                return true;
            }
            else
            {
                Console.WriteLine("Test_CambiarTempo: Fallo");
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
            bool resultado = (notaCabeza == "DO" && figuraCabeza == "negra" && notaViejo == "MI" && figuraViejo == "blanca");
            if (resultado)
            {
                Console.WriteLine("Test_Insertar_Partitura: Paso");
                return true;
            }
            else
            {
                Console.WriteLine("Test_Insertar_Partitura: Fallo");
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
            bool resultado = (nota1 == "DO" && nota2 == "RE" && nota3 == "MI");
            if (resultado)
            {
                Console.WriteLine("Test_Reproducir_Partitura: Paso");
                return true;
            }
            else
            {
                Console.WriteLine("Test_Reproducir_Partitura: Fallo");
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
            bool resultado = (nota1 == "MI" && nota2 == "RE" && nota3 == "DO");
            if (resultado)
            {
                Console.WriteLine("Test_Reproducir_Partitura_Alreves: Paso");
                return true;
            }
            else
            {
                Console.WriteLine("Test_Reproducir_Partitura_Alreves: Fallo");
                return false;
            }
        }

        static bool Test_Nodo_Constructor()
        {
            var nodo = new Nodo("LA", "blanca");
            var (nota, figura) = nodo.getDato();
            bool resultado = (nodo.siguiente == null && nodo.anterior == null && nota == "LA" && figura == "blanca");
            if (resultado)
            {
                Console.WriteLine("Test_Nodo_Constructor: Paso");
                return true;
            }
            else
            {
                Console.WriteLine("Test_Nodo_Constructor: Fallo");
                return false;
            }
        }

        static bool Test_ObtenerFrecuencia_Excepcion()
        {
            var reproductor = new ReproductorMusical();
            try
            {
                reproductor.ObtenerFrecuencia("XYZ");
                Console.WriteLine("Test_ObtenerFrecuencia_Excepcion: Fallo");
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Test_ObtenerFrecuencia_Excepcion: Paso");
                return true;
            }
        }

        static bool Test_ObtenerMs_Excepcion()
        {
            var reproductor = new ReproductorMusical();
            try
            {
                reproductor.ObtenerMs("invalida");
                Console.WriteLine("Test_ObtenerMs_Excepcion: Fallo");
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Test_ObtenerMs_Excepcion: Paso");
                return true;
            }
        }

        static bool Test_CambiarTempo_Excepcion()
        {
            var reproductor = new ReproductorMusical();
            try
            {
                reproductor.CambiarTempo(10.0);
                Console.WriteLine("Test_CambiarTempo_Excepcion: Fallo");
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Test_CambiarTempo_Excepcion: Paso");
                return true;
            }
        }
    }
}