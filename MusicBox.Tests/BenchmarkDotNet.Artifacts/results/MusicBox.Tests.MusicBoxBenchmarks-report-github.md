```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8037/25H2/2025Update/HudsonValley2)
13th Gen Intel Core i9-13900HX 2.20GHz, 1 CPU, 32 logical and 24 physical cores
.NET SDK 9.0.304
  [Host]     : .NET 9.0.8 (9.0.8, 9.0.825.36511), X64 RyuJIT x86-64-v3
  Job-CMDOCI : .NET 9.0.8 (9.0.8, 9.0.825.36511), X64 RyuJIT x86-64-v3

IterationCount=50  

```
| Method                         | Mean        | Error     | StdDev    | Median      | Gen0    | Gen1    | Allocated |
|------------------------------- |------------:|----------:|----------:|------------:|--------:|--------:|----------:|
| Benchmark_Insertar_100_Notas   |    346.5 ns |   1.07 ns |   2.07 ns |    346.1 ns |  0.2546 |  0.0043 |    4800 B |
| Benchmark_Insertar_1000_Notas  |  3,491.3 ns |  13.41 ns |  26.78 ns |  3,488.5 ns |  2.5482 |  0.3929 |   48000 B |
| Benchmark_Insertar_10000_Notas | 39,842.8 ns | 148.98 ns | 279.81 ns | 39,810.4 ns | 25.4517 | 16.6016 |  480000 B |
| Benchmark_ObtenerFrecuencia    |    184.2 ns |   8.25 ns |  15.90 ns |    176.1 ns |  0.0527 |       - |     992 B |
| Benchmark_ObtenerMs            |    201.9 ns |   6.46 ns |  12.45 ns |    198.8 ns |  0.0505 |       - |     960 B |
