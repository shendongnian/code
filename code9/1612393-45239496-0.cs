    Assembly asm = Assembly.LoadFile(@"pathToDllHere\ProjectA.dll");
    
    Type t = asm.GetType("ProjectA.ClassName");
    
    MethodInfo methodInfo = t.GetMethod("MyMethod", new Type[] { typeof(string), typeof(int) });
    
    Object o = Activator.CreateInstance(t);
    
    object[] parameters = new object[2]
    {
    	"sample parameter", 1337
    };
    
    var result = methodInfo.Invoke(o, parameters);
    
    Console.WriteLine(result);
