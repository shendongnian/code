    class Program
    {
	  private static Program programInstance = new Program();
	  static void Main(string[] args)
	  {
		InvokerClass.StartInvokeExample<Program>("Hello", "World!");
	  }
	  public static void thisMethod(String data1, String data2)
	  {
		Console.WriteLine("DATA1=>" + data1 + ", DATA2=>" + data2);
	  }
    }
    class static InvokerClass
    {
	  //Do invoking here
	  public void StartInvokeExample<T>(String data1, String data2)
	  {
        Type t = typeof(T); 
		ConstructorInfo cons = t.GetConstructor(Type.EmptyTypes);
		object classObject = cons.Invoke(new object[] { });
		MethodInfo m = t.GetMethod("thisMethod");
		m.Invoke(classObject, new object[] { data1, data2 });
	  }
	  public static StartInvokeExample
       (Type t, String data1, String data2)
	  {
		ConstructorInfo cons = t.GetConstructor(Type.EmptyTypes);
		object classObject = cons.Invoke(new object[] { });
		MethodInfo m = t.GetMethod("thisMethod");
		m.Invoke(classObject, new object[] { data1, data2 });
	  }
    }
