    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Emit;
    using System.Reflection;
    namespace ExecuteText
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
                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(TextBox.Text);
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
                var err = "";
                foreach (var diagnostic in failures)
                   err += $"{diagnostic.Id}: {diagnostic.GetMessage()}";
    
                ErrorTextBox.AppendText(err);
            }
    
            /**************************************************************************************************
            * Executes the compiled code operation.
            *
            * @param ms The milliseconds.
            **************************************************************************************************/
    
            private  void ExecuteCompiledCode(MemoryStream ms)
            {
                ms.Seek(0, SeekOrigin.Begin);
                var assembly = Assembly.Load(ms.ToArray());
    
                var type = assembly.GetType("AStringOfCode.FunctionClass");
                var obj = Activator.CreateInstance(type);
                type.InvokeMember("Run",
                                  BindingFlags.Default | BindingFlags.InvokeMethod,
                                  null,
                                  obj,
                                  new object[] {Block});
                ShowPosition();
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
    
            private void ShowPosition()
            {
                PositionTextBox.Text = Block.Location.X + "," + Block.Location.Y;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
               ShowPosition(); 
            }
    
    
            private void Run_Click(object sender, EventArgs e)
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
    
            private void TextBox_TextChanged(object sender, EventArgs e)
            {
    
            }
        }
    
    }
