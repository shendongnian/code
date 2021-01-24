    public class Program  {
    void Main() {
        var constructorInfo = typeof(Program).GetConstructors()[0];
        var parm = Expression.Parameter(typeof(object[]), "args");
        var someType1Exp = Expression.New(constructorInfo, parm);
        var outer = Expression.Lambda<Func<object[], object>>(someType1Exp, parm);
        var func = outer.Compile();
    
        object[] values = { 1, 123.45F, "abc" };
        object obj = func(values);
        Console.WriteLine(obj);
        Console.WriteLine("test");
    }
    
    // Define other methods and classes here
        public Program(object[] parms) {
            Console.WriteLine(parms.ToString());
        }
    }
