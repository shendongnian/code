    var ws = new AdhocWorkspace();
    var proj = ws.AddProject("test", "C#")
                    .AddMetadataReference(
                        MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
    proj = proj.WithParseOptions(proj.ParseOptions
        .WithFeatures(new Dictionary<string, string> { ["IOperation"] = "true" }));
    var doc = proj.AddDocument("test.cs", SourceText.From(@"using System;
    namespace Test {
        public class Program{
            public static void Main(){
                Func<int> x = Foo;
            }
            private static int Foo() => 7;
            private static int Foo(int x) => 8;
        }
    }"));
    proj = doc.Project;
    
    var compilation = proj.GetCompilationAsync().GetAwaiter().GetResult();
    var tree = doc.GetSyntaxTreeAsync().GetAwaiter().GetResult();
    var model = compilation.GetSemanticModel(tree);
    var fooToken = tree.GetRoot().DescendantTokens().First(t => t.Text == "Foo");
    Console.WriteLine(model.GetSymbolInfo(fooToken.Parent).Symbol);
    Console.WriteLine(model.GetMemberGroup(fooToken.Parent).Length);
