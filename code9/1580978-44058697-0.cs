    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"
    using System;
    using System.Collections.Generic;
    Console.WriteLine(""I only need to use System"");";
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(text, new CSharpParseOptions(kind: SourceCodeKind.Script));
            var coreDir = Path.GetDirectoryName(typeof(object).GetTypeInfo().Assembly.Location);
            var mscorlib = MetadataReference.CreateFromFile(Path.Combine(coreDir, "mscorlib.dll"));
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
            var compilation = CSharpCompilation.Create("MyAssembly")
                .AddSyntaxTrees(syntaxTree)
                .AddReferences(mscorlib)
                .WithOptions(options);
            foreach (var d in compilation.GetDiagnostics())
            {
                Console.WriteLine($"{d.Id}: {d.GetMessage()}");
            }
        }
    }
