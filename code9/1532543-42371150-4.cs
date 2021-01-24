    private void CreateAndRelease()
    {
      new TestClass();
    }
    public void Main()
    {
      CreateAndRelease();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      Console.ReadLine();
    }
