    class Program
    {
        static void Main(string[] args)
        {
            // stores a reference to the value returned by M1(), which is to say,
            // a reference to the B._o field.
            ref A a1 = ref B.M1();
            // Keep the original value, and create a new A instance
            A original = a1, a2 = new A();
            // Update the B._o field to the new A instance
            B.M2(a2);
            // Check the current state
            Console.WriteLine($"original.ID: {original.ID}");
            Console.WriteLine($"a1.ID: {a1.ID}");
            Console.WriteLine($"a2.ID: {a2.ID}");
        }
    }
    class A
    {
        private static int _id;
        public int ID { get; }
        public A()
        {
            ID = ++_id;
        }
    }
    class B
    {
        private static A _o = new A();
        public static ref A M1()
        {
            // returns a _reference_ to the _o field, rather than a copy of its value
            return ref _o;
        }
        public static void M2(A o)
        {
            _o = o;
        }
    }
