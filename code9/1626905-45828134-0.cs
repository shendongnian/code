    // this data represents your excel data
    var data = new string[][] {
        new string [] { "col_1_1", "10", "09:30" },
        new string [] { "col_2_1", "12", "09:40" }
    };
    // you should read this from your client specific config file/section
    // Remember: you should provide a GUI tool to build this config
    var config = @"
                output.Add(input[0]);
                int hours = int.Parse(input[1]);
                DateTime date = DateTime.Parse(input[2]);
                date = date.AddHours(hours);
                output.Add(""Custom Text: "" + date);
    ";
    // this template code should be picked up from a 
    // non client specific config file/section
    var code = @"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ClientLibrary {
        static class ClientLibrary {
            public static List<string> Client1(string[] input) {
                var output = new List<string>();
                <<code-from-config>>
                return output;
            }
        }
    }
    ";
    
    // Inject client configuration into template to form full code
    code = code.Replace(@"<<code-from-config>>", config);
    // Compile your dynamic method and get a reference to it
    var references = new MetadataReference[] {
        MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
        MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
    };
    CSharpCompilation compilation = CSharpCompilation.Create(
        null,
        syntaxTrees: new[] { CSharpSyntaxTree.ParseText(code) },
        references: references,
        options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
    MethodInfo clientMethod = null;
    using (var ms = new MemoryStream()) {
        EmitResult result = compilation.Emit(ms);
        if (!result.Success) {
            foreach (Diagnostic diagnostic in result.Diagnostics) {
                Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
            }
        } else {
            ms.Seek(0, SeekOrigin.Begin);
            Assembly assembly = Assembly.Load(ms.ToArray());
            clientMethod = assembly.GetType("ClientLibrary.ClientLibrary").GetMethod("Client1");
        }
    }
    if (clientMethod == null)
        return;
    // Do transformation
    foreach (string[] row in data) {
        var output = clientMethod.Invoke(null, new object[] { row }) as List<string>;
        Console.WriteLine(string.Join("|", output));
    }
