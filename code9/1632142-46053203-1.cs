    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.FindSymbols;
    using Microsoft.CodeAnalysis.MSBuild;
    
    namespace AnalyzeIndexers
    {
        class Program
        {
            static void Main(string[] args)
            {
                string solutionPath = @"PathToSolution.sln";
                var msWorkspace = MSBuildWorkspace.Create();
                var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
    
                foreach (var project in solution.Projects.Where(p => p.AssemblyName.StartsWith("TestApp")))
                {
                    var compilation = project.GetCompilationAsync().Result;
                    var interfaceType = compilation.GetTypeByMetadataName("TestApp.IIndexed");
                    var indexer = interfaceType
                        .GetMembers()
                        .OfType<IPropertySymbol>()
                        .First(member => member.IsIndexer);
                    
                    var indexReferences = SymbolFinder.FindReferencesAsync(indexer, solution).Result.ToList();
    
                    foreach (var indexReference in indexReferences)
                    {
                        foreach (ReferenceLocation indexReferenceLocation in indexReference.Locations)
                        {
                            int spanStart = indexReferenceLocation.Location.SourceSpan.Start;
                            var doc = indexReferenceLocation.Document;
    
                            var indexerInvokation = doc.GetSyntaxRootAsync().Result
                                .DescendantNodes()
                                .FirstOrDefault(node => node.GetLocation().SourceSpan.Start == spanStart);
    
                            var className = indexerInvokation.Ancestors()
                                .OfType<ClassDeclarationSyntax>()
                                .FirstOrDefault()
                                ?.Identifier.Text ?? String.Empty;
    
                            var @namespace = indexerInvokation.Ancestors()
                                .OfType<NamespaceDeclarationSyntax>()
                                .FirstOrDefault()
                                ?.Name.ToString() ?? String.Empty;
    
    
                            Console.WriteLine($"{@namespace}.{className} : {indexerInvokation.GetText()}");
                        }
                    }
                }
    
                Console.WriteLine();
                Console.ReadKey();
    
            }
        }
    }
