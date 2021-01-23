    internal class PolicyExpressionEvaluator
    {
        private readonly ScriptRunner<double> EvaluateInternal;
        public PolicyExpressionEvaluator(string expression)
        {
            var usings = new[] 
            {
                "System",
                "System.Collections.Generic",
                "System.Linq",
                "System.Threading.Tasks"
            };
            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                .ToArray();
            var options = ScriptOptions.Default
                .AddImports(usings)
                .AddReferences(references);
            this.EvaluateInternal = CSharpScript.Create<double>(expression, options, globalsType: typeof(PolicyEvaluatorGlobals))
                .CreateDelegate();
        }
        internal double Evaluate(Policy policy)
        {
            return EvaluateInternal(new PolicyEvaluatorGlobals(policy)).Result;
        }
    }
