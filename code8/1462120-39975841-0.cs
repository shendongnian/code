    class Program
    {
	  static InvokerClass<Program> ic;
	  private static Program programInstance = new Program();
	  static void Main(string[] args)
	  {
		ic = new InvokerClass<Program>();
		ic.StartInvokeExample("Hello", "World!");
	  }
	  public static void thisMethod(String data1, String data2)
	  {
		Console.WriteLine("DATA1=>" + data1 + ", DATA2=>" + data2);
	  }
    }
    class InvokerClass<T>
    {
	  //Do invoking here
	  public void StartInvokeExample(String data1, String data2)
	  {
        Type t = typeof(T); 
		ConstructorInfo cons = t.GetConstructor(Type.EmptyTypes);
		object classObject = cons.Invoke(new object[] { });
		MethodInfo m = t.GetMethod("thisMethod");
		m.Invoke(classObject, new object[] { data1, data2 });
	  }
    }
