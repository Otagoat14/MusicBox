//MusicBoxBenchmarks
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MusicBox.core;

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
}