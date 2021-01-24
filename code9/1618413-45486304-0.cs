    class Program
    {
        public event Action Event;
        private void RaiseEventInOrder()
        {
            var handlers = (Event?.GetInvocationList().Cast<Action>() ?? Enumerable.Empty<Action>())
                .Select(h => new
                {
                    Handler = h,
                    Order = h.Method.GetCustomAttribute<InvocationOrderAttribute>()?.Order ?? int.MaxValue
                })
                .OrderBy(ha => ha.Order)
                .Select(ha => ha.Handler);
            foreach (var h in handlers) h();
        }
        [InvocationOrder(1)]
        private static void M1() => Console.WriteLine("M1");
        [InvocationOrder(2)]
        private static void M2() => Console.WriteLine("M2");
        private static void M3() => Console.WriteLine("M3");
        public static void Main()
        {
            var p = new Program();
            p.Event += M3;
            p.Event += M2;
            p.Event += M1;
            p.Event += M3;
            p.Event += M2;
            p.Event += M1;
            p.RaiseEventInOrder();
        }
    }
