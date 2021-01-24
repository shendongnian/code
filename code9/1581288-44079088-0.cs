    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Emit;
    
    namespace WindowsFormsApplication1
    {
    
        /**************************************************************************************************
        * A form 1.
        *
        * @sa System.Windows.Forms.Form
        **************************************************************************************************/
    
        public partial class Form1 : Form
        {
    
            /**************************************************************************************************
            * Default constructor.
            **************************************************************************************************/
    
            public Form1()
            {
                InitializeComponent();
            }
    
            /**************************************************************************************************
            * Gets the assembly files in this collection.
            *
            * @param assembly The assembly.
            *
            * @return An enumerator that allows foreach to be used to process the assembly files in this
            * collection.
            **************************************************************************************************/
    
            IEnumerable<string> GetAssemblyFiles(Assembly assembly)
            {
                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assemblyName in assembly.GetReferencedAssemblies())
                    yield return loadedAssemblies.SingleOrDefault(a => a.FullName == assemblyName.FullName)?.Location;
            }
    
            /**************************************************************************************************
            * Creates compiler context.
            *
            * @return The new compiler context.
            **************************************************************************************************/
    
            private CSharpCompilation CreateCompilerContext()
            {
                var assemblyName = Path.GetRandomFileName();
                Assembly a = typeof(Form1).Assembly;
                var refs = GetMetadataReferencesInAssembly(a);
    
                var compilation = CSharpCompilation.Create(
                                                           assemblyName,
                                                           new[] {syntaxTree},
                                                           refs.ToArray(),
                                                           new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
                return compilation;
            }
    
            /**************************************************************************************************
            * Console write errors.
            *
            * @param result The result.
            **************************************************************************************************/
    
            private void ConsoleWriteErrors(EmitResult result)
            {
                var failures = result.Diagnostics.Where(CodeHasError);
    
                foreach (var diagnostic in failures)
                    Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
            }
    
            /**************************************************************************************************
            * Executes the compiled code operation.
            *
            * @param ms The milliseconds.
            **************************************************************************************************/
    
            private static void ExecuteCompiledCode(MemoryStream ms)
            {
                ms.Seek(0, SeekOrigin.Begin);
                var assembly = Assembly.Load(ms.ToArray());
    
                var type = assembly.GetType("AStringOfCode.FunctionClass");
                var obj = Activator.CreateInstance(type);
                type.InvokeMember("Hello",
                                  BindingFlags.Default | BindingFlags.InvokeMethod,
                                  null,
                                  obj,
                                  new object[] {"Hello World"});
            }
    
            /**************************************************************************************************
            * Gets metadata references in assembly.
            *
            * @param assembly The assembly.
            *
            * @return The metadata references in assembly.
            **************************************************************************************************/
    
            private List<MetadataReference> GetMetadataReferencesInAssembly(Assembly assembly)
            {
    
    
                var assemblyFiles = GetAssemblyFiles(assembly);
    
                Console.WriteLine(assemblyFiles);
    
                List<MetadataReference> refs = new List<MetadataReference>();
                foreach (var assemblyname in assemblyFiles)
                    refs.Add(MetadataReference.CreateFromFile(assemblyname));
                return refs;
            }
    
            private readonly SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"  // The syntax tree
        using System;
        using System.Windows.Forms;
    
        namespace AStringOfCode
        {
            public class FunctionClass
            {
                public void Hello(string message)
                {
                    MessageBox.Show(message);
                }
            }
        }");
    
            /**************************************************************************************************
            * Code has error.
            *
            * @param diagnostic The diagnostic.
            *
            * @return True if it succeeds, false if it fails.
            **************************************************************************************************/
    
            private bool CodeHasError(Diagnostic diagnostic)
            {
                return diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error;
            }
    
            /**************************************************************************************************
            * Event handler. Called by button1 for click events.
            *
            * @param sender Source of the event.
            * @param e      Event information.
            **************************************************************************************************/
    
            private void Demo(object sender, EventArgs e)
            {
                var compilation = CreateCompilerContext();
                using (var ms = new MemoryStream())
                {
                    var result = compilation.Emit(ms);
    
                    if (result.Success)
                    {
                        ExecuteCompiledCode(ms);
                    }
                    else
                    {
                        ConsoleWriteErrors(result);
                    }
                }
            }
        }
    
    }
