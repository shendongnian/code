    class RefExample
    {
        static void Method(ref int i)
        {
            // The following statement would cause a compiler error if i
            // were boxed as an object.
            i = i + 44;
        }
        static void Main()
        {
            int val = 1;
            Method(ref val);
            Console.WriteLine(val);
            // Output: 45
        }
    }
