    class SpecificAdaptee
    {
        ...
        public void FireEvent2()
        {
            int a = 42;
            if (Event2 != null)
                Event2(this, ref a);
            Console.WriteLine("A value after the event is {0}", a);
        }
    }
        private static void OnAdaptedEvent2(object sender, AdaptedEventArgs2 args)
        {
            Console.WriteLine($"{nameof(OnAdaptedEvent2)}({sender}, {args.A})");
            args.A = 15;
        }
