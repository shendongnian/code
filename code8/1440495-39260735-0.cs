        string testClass = @"using System; 
        namespace test{
         public class tes
         {
           public string unescape(string Text)
          { 
            return Uri.UnescapeDataString(Text);
          } 
         }
        }";
        var dd = typeof(Enumerable).GetTypeInfo().Assembly.Location;
        var coreDir = Directory.GetParent(dd);
        var compilation = CSharpCompilation.Create(Guid.NewGuid().ToString() + ".dll")
            .WithOptions(new CSharpCompilationOptions(Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary))
            .AddReferences(
            MetadataReference.CreateFromFile(typeof(Object).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Uri).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(coreDir.FullName + Path.DirectorySeparatorChar + "mscorlib.dll"),
            MetadataReference.CreateFromFile(coreDir.FullName + Path.DirectorySeparatorChar + "System.Runtime.dll")
            )
            .AddSyntaxTrees(CSharpSyntaxTree.ParseText(testClass));
        var eResult = compilation.Emit("test.dll");
