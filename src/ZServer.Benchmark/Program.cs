﻿using System;

namespace ZServer.Benchmark;

class Program
{
    static void Main(string[] args)
    {
//             var testClass = new RendererTest();
//             testClass.DrawAllStyle256OneTime();
// #if !DEBUG
//             BenchmarkDotNet.Running.BenchmarkRunner.Run<RendererTest>();
// #endif
        BenchmarkDotNet.Running.BenchmarkRunner.Run<StreamToArray>();
        Console.WriteLine("Bye!");
    }
}