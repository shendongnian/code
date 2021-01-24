    void Main()
    {
    
      Console.WriteLine(Type.GetType("A").GetMethod("Hi").Invoke(null, new object[] {}));
    }
    
    class A
    {
      public static string Hi() { return "Hi!"; }
    }
