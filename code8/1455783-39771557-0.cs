    public class Foo
    {
        private Evaluator _evaluator;
        private StringBuilder _errors;
        public Foo(object context, string contextName) {
            this._errors = new StringBuilder();
            var tw = new StringWriter(this._errors);
            var ctx = new CompilerContext(new CompilerSettings() {
                AssemblyReferences = new List<string> {
                    Assembly.GetExecutingAssembly().FullName
                }
            }, new StreamReportPrinter(tw));
            var eval = new Evaluator(ctx);
            string usings = @"
        using System;
        using System.Drawing; 
        using System.Collections.Generic;
        using System.Linq; ";
            eval.Run(usings);
            object result;
            bool results;
            // here we initialize our variable, but set it to null
            var constructor = $"{context.GetType().FullName} {contextName} = null;";
            eval.Evaluate(constructor, out result, out results);
            // here we use reflection to get private field which stores information about available variables
            FieldInfo fieldInfo = typeof(Evaluator).GetField("fields", BindingFlags.NonPublic | BindingFlags.Instance);
            var fields = fieldInfo.GetValue(eval) as Dictionary<string, Tuple<FieldSpec, FieldInfo>>;
            // and we set variable we just created above to the "context" external object
            fields[contextName].Item2.SetValue(eval, context);
            this._evaluator = eval;
        }
        public string Evaluate(string expression)
        {
            try
            {
                object result;
                bool results;
                this._errors.Clear();
                this._evaluator.Evaluate(expression, out result, out results);
                if (results)
                {
                    return result.ToString();
                }
                if (this._errors.Length > 0)
                {
                    return this._errors.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
    }
