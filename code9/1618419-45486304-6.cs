    public static class Program
    {
        private static event Action Event;
        private static void RaiseEvent()
        {
            foreach (var h in MyAwesomeCode.OrderedInvocationList(Event))
                h();
        }
        [InvocationOrder(1)]
        private static void M1() { Console.WriteLine("M1"); }
        [InvocationOrder(2)]
        private static void M2() { Console.WriteLine("M2"); }
        private static void M3() { Console.WriteLine("M3"); }
        public static void Main()
        {
            RaiseEvent(); // works on empty invocation list
            Event += M3;
            Event += M2;
            Event += M1;
            Event += M3;
            Event += M2;
            Event += M1;
            RaiseEvent(); // works with methods not carrying the attribute
        }
    }
