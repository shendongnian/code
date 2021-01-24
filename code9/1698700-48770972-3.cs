     public static void TestLongRunning()
     {
         ConcreteRunningClass concrete = new ConcreteRunningClass();
         concrete.OnBeforeMethodExecution += Concrete_OnBeforeMethodExecution;
         concrete.SomeLongRunningMethod();
     }
     private static void Concrete_OnBeforeMethodExecution(ILongRunningWithEvents<SampleArgs> sender, SampleArgs args, string caller)
    {
        Console.WriteLine("{0}: {1}", caller ?? "unknown", args.Message);
    }
