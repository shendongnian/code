    Output:
    Disposing TestClass.
    Finished
    public static void Main()
    {
      using (TestClass test = new TestClass())
      {}
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      Console.WriteLine("Finished");
      Console.ReadLine();
    }
