    public class C
    {
        public string TestValue(string hello, Guid world)
        {
            return hello + world;
        }
    
        public string Execute()
        {
            var objectParams = new Dictionary<string, object>()
            {
                {"hello", "somestring"},
                {"world", Guid.NewGuid()}
            };
            var method = this.GetType().GetMethod("TestValue");
            var methodParameters = method.GetParameters();
            var paramMatcher = (from paramValue in objectParams
                from methodParam in methodParameters
                where paramValue.Key == methodParam.Name
                orderby methodParam.Position  // <-- preserves original order
                select (name: methodParam.Name,
                type: methodParam.ParameterType,
                value: paramValue.Value));
    
            var paramExpress = (from param in paramMatcher
                 select Expression.Assign(Expression.Parameter(param.type, param.name),
                        Expression.Constant(param.value, param.type)));
            var values = paramExpress.Select(v => v.Right); // !!!
            Func<string> result = Expression.Lambda<Func<string>>(Expression.Call(Expression.Constant(this),
                method, values)).Compile();
            return result.Invoke(); // returns "somestringxxxxxxx-xxxx..."
        }
    }
