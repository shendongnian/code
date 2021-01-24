    public class Evaluator
    {
        public int Evaluate(string expression)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.ReferencedAssemblies.Add("system.dll");
            compilerParameters.CompilerOptions = "/t:library";
            compilerParameters.GenerateInMemory = true;
            StringBuilder typeDefinition = new StringBuilder("");
            typeDefinition.AppendLine("using System;");
            typeDefinition.AppendLine("namespace Evaluator");
            typeDefinition.AppendLine("{");
            typeDefinition.AppendLine("    public class Evaluator");
            typeDefinition.AppendLine("    {");
            typeDefinition.AppendLine("        public object Evaluate()");
            typeDefinition.AppendLine("        {");
            typeDefinition.AppendLine("            return " + expression + ";");
            typeDefinition.AppendLine("        }");
            typeDefinition.AppendLine("    }");
            typeDefinition.AppendLine("}");
            CompilerResults compilerResult = codeProvider.CompileAssemblyFromSource(compilerParameters, typeDefinition.ToString());
            System.Reflection.Assembly a = compilerResult.CompiledAssembly;
            object o = a.CreateInstance("Evaluator.Evaluator");
            Type dynamicEvaluatorType = o.GetType();
            MethodInfo dynamicEvaluateMethod = dynamicEvaluatorType.GetMethod("Evaluate");
            return (int) dynamicEvaluateMethod.Invoke(o, null);
        }
    }
