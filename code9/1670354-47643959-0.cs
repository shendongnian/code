    class Program
        {
            static void Main(string[] argas)
            {
                var constructorInfo = typeof(Program).GetConstructors()[0];
                var types = constructorInfo.GetParameters().Select(p => p.ParameterType);
                var parm = Expression.Parameter(typeof(object[]), "args");
                var parameters = types.Select((t, i) => Expression.Convert(Expression.ArrayIndex(parm, Expression.Constant(i)), t)).ToArray();
                var someType1Exp = Expression.New(constructorInfo, parameters);
                var outer = Expression.Lambda<Func<object[], object>>(someType1Exp, parm);
                var func = outer.Compile();
    
                object[] values = { 1, 123.45F, "abc" };
                object obj = func(values);
                Console.WriteLine(obj);
                Console.WriteLine("test");
                Console.ReadLine();
            }
            //public Program() { }
            public Program(int val1, float val2, string val3) { 
                Console.WriteLine(val1);
                Console.WriteLine(val2);
                Console.WriteLine(val3);
            }
        }
