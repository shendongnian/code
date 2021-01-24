    struct S
    {
        public bool Equals(int x, int y)
        {
            return false;
        }
    }
    class C
    {
        public static void Main()
        {
            S? S = new S();
            Console.WriteLine(S?.Equals(1, 1));
        }
    }
