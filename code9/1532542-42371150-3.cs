    Disposing TestClass.
    TestClass Finalizer called
    Finished
    public static void Main()
    {
      CreateAndRelease();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      Console.WriteLine("Finished");
      Console.ReadLine();
    }
    private static void CreateAndRelease()
    {
      using (TestClass test = new TestClass())
      {}
    }
    
