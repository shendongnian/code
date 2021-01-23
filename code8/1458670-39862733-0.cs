    class Program
    {
        static void A(double a)
        {
            if (a > 1.0)
                a = 1.0;
            else if (a < -1.0)
                a = -1.0;
        }
        static void B(double a)
        {
            if (Math.Abs(a) > 1.0)
                a = a < 0 ? -1.0 : 1.0;
        }
        static void Main(string[] args)
        {
            A(-1.17);
            B(-1.17);
        }
    }
