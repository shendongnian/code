    class DoneLogger : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Done");
        }
    }
    DoSomethingThatTakesVeryLong(new DoneLogger());
