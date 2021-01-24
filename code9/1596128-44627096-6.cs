     static void InspectDelegate(object obj)
     {
         if (!(obj is Delegate del))
             return;
         var returnType = del.Method.ReturnType.Name;
         var parameters = del.Method.GetParameters();
         Dictionary<string, string> argNames = 
                       parameters.ToDictionary(a => a.Name, b => b.ParameterType.Name);
         if (obj is Action<string, int>)
             del.DynamicInvoke("foo", 2);
     }
     static void Main(string[] args)
     {
         Action<string, int> act = (x, y) => { Console.WriteLine("x={0}, y= {1}", x, y); };
         InspectDelegate(act);
     }
