    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    
    namespace SandboxConsole
    {
        class Program
        {
            public static void Main()
            {
                var text = File.ReadAllText("MyClass.cs");
                var tree = CSharpSyntaxTree.ParseText(text);
    
                var method = tree.GetRoot().DescendantNodes()
                             .OfType<MethodDeclarationSyntax>()
                             .First(x => x.Identifier.Text == "ComplexMethodV");
    
                Console.WriteLine(method.ToFullString());
                Console.ReadLine();
            }
        }
    }
