        static void Main(string[] args)
        {
            Dictionary<string, object> variables = new Dictionary<string, object>();
            variables.Add("x", 1000);
            variables.Add("y", 200);
            string equation = "x*12/100+y*5/100";
            var result = Calculate(variables, equation);
        }
        static object Calculate(Dictionary<string, object> variables, string equation)
        {
            variables.ToList().ForEach(v => equation = equation.Replace(v.Key, v.Value.ToString()));
            return new DataTable().Compute(equation, string.Empty);
        }
