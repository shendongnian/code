    using System;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    //...
    
    private static void Main()
    {
        string x = "\\b";
        string res = Evaluate(x);
        Console.WriteLine(res);
    }
    public static string Evaluate(string input)
    {
        // code to compile.
        const string format = "namespace EscapeSequenceMapper {{public class Program{{public static string Main(){{ return \"{0}\";}}}}}}";
        // compile code.
        var cr = new CSharpCodeProvider().CompileAssemblyFromSource(
            new CompilerParameters { GenerateInMemory = true }, string.Format(format, input));
        if (cr.Errors.HasErrors) return null;
        // get the method and invoke.
        var method = cr.CompiledAssembly.GetType("EscapeSequenceMapper.Program").GetMethod("Main");
        return (string)method.Invoke(null, null);
    }
