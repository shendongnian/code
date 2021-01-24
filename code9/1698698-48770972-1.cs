     public static void TestLongRunning()
     {
         ConcreteRunningClass concrete = new ConcreteRunningClass();
         concrete.OnBeforeMethodExecution += Concrete_OnBeforeMethodExecution;
         concrete.SomeLongRunningMethod();
     }
     private static void Concrete_OnBeforeMethodExecution(ILongRunningWithEvents<SampleArgs> sender, SampleArgs args)
     {
         Console.WriteLine(args.Message);
     }
