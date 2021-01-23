    class Program
    {
        static void Main(string[] args)
        {
            // this is slow, only do this once per expression
            var evaluator = new PolicyExpressionEvaluator("Policy.Premium * 1.05");
            // this is fairly fast
            var policy1 = new Policy() { Premium = 100, Year = 2016 };
            var result1 = evaluator.Evaluate(policy1);
            var policy2 = new Policy() { Premium = 150, Year = 2016 };
            var result2 = evaluator.Evaluate(policy2);
            Console.WriteLine($"Policy 1: {result1}, Policy 2: {result2}");
        }
    }
    public class Policy
    {
        public double Premium, Year;
    }
    class PolicyExpressionEvaluator
    {
        const string 
            ParamName = "Policy",
            ResultName = "result";
        public PolicyExpressionEvaluator(string expression)
        {
            var paramVariable = new Variable<Policy>(ParamName);
            var resultVariable = new Variable<double>(ResultName);
            var daRoot = new DynamicActivity()
            {
                Name = "DemoExpressionActivity",
                Properties =
                {
                    new DynamicActivityProperty() { Name = ParamName, Type = typeof(InArgument<Policy>) },
                    new DynamicActivityProperty() { Name = ResultName, Type = typeof(OutArgument<double>) }
                },
                Implementation = () => new Assign<double>()
                {
                    To = new ArgumentReference<double>() { ArgumentName = ResultName },
                    Value = new InArgument<double>(new CSharpValue<double>(expression))
                }
            };
            CSharpExpressionTools.CompileExpressions(daRoot, typeof(Policy).Assembly);
            this.Activity = daRoot;
        }
        public DynamicActivity Activity { get; }
        public double Evaluate(Policy p)
        {
            var results = WorkflowInvoker.Invoke(this.Activity, 
                new Dictionary<string, object>() { { ParamName, p } });
            return (double)results[ResultName];
        }
    }
    internal static class CSharpExpressionTools
    {
        public static void CompileExpressions(DynamicActivity dynamicActivity, params Assembly[] references)
        {
            // See https://docs.microsoft.com/en-us/dotnet/framework/windows-workflow-foundation/csharp-expressions
            string activityName = dynamicActivity.Name;
            string activityType = activityName.Split('.').Last() + "_CompiledExpressionRoot";
            string activityNamespace = string.Join(".", activityName.Split('.').Reverse().Skip(1).Reverse());
            TextExpressionCompilerSettings settings = new TextExpressionCompilerSettings
            {
                Activity = dynamicActivity,
                Language = "C#",
                ActivityName = activityType,
                ActivityNamespace = activityNamespace,
                RootNamespace = null,
                GenerateAsPartialClass = false,
                AlwaysGenerateSource = true,
                ForImplementation = true
            };
            // add assembly references
            TextExpression.SetReferencesForImplementation(dynamicActivity, references.Select(a => (AssemblyReference)a).ToList());
            // Compile the C# expression.  
            var results = new TextExpressionCompiler(settings).Compile();
            if (results.HasErrors)
            {
                throw new Exception("Compilation failed.");
            }
            // attach compilation result to live activity
            var compiledExpression = (ICompiledExpressionRoot)Activator.CreateInstance(results.ResultType, new object[] { dynamicActivity });
            CompiledExpressionInvoker.SetCompiledExpressionRootForImplementation(dynamicActivity, compiledExpression);
        }
    }
