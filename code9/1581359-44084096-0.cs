    public static void TestCodeAnalizer()
            {
    
                //var scriptOptions = ScriptOptions.Default.WithReferences("Microsoft.CSharp")
                var text = @"using System.Linq; 
    
                public class Calculator
                {
    
                public int number3 = 0;
    
                public static object AddTwoNumbers(int number1, int number2)
                {
                    return (number1 + number2);
                }
    
                public static int AddThreeNumbers(int number1, int number2)
                {
                    Calculator calculator = new Calculator();
                    return calculator.AddThreeNumbersNonStatic(2,2,5);
                }
    
                public int AddThreeNumbersNonStatic(int number1, int number2, int number3)
                {
                    this.number3 = number3;
                     
                    return (number1 + number2 + this.number3);
                }
    
                }";
    
                var tree = SyntaxFactory.ParseSyntaxTree(text);
                var compilation = CSharpCompilation.Create(
                    "calc.dll",
                    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary),
                    syntaxTrees: new[] { tree },
                    references: new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location), MetadataReference.CreateFromFile(typeof(ExpandoObject).Assembly.Location) });
    
                Assembly compiledAssembly;
                using (var stream = new MemoryStream())
                {
                    var compileResult = compilation.Emit(stream);
                    compiledAssembly = Assembly.Load(stream.GetBuffer());
                }
    
                Type calculator = compiledAssembly.GetType("Calculator");
    
                //my send parameters :D
                object[] parametersArray = new object[] { 2, 2 };
    
                //first answer
                MethodInfo evaluate_AddTwoNumbers = calculator.GetMethod("AddTwoNumbers");
                string answer_AddTwoNumbers = evaluate_AddTwoNumbers.Invoke(null, parametersArray).ToString();
    
                //second answer
                MethodInfo evaluate_AddThreeNumbers = calculator.GetMethod("AddThreeNumbers");
                string answer_AddThreeNumbers = evaluate_AddThreeNumbers.Invoke(null, parametersArray).ToString();
    
    
            }
