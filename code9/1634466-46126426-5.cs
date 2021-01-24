    class Program
    {
        static void Main(string[] args)
        {
            C<int> c1 = new C<int>();
            C<bool> c2 = new C<bool>();
            c1.M1();
            c1.M2();
            c1.M2();
            c2.M1();
            c2.M1();
            c2.M1();
            c2.M2();
            c2.M2();
            c2.M2();
            c2.M2();
            C.ReportCounts();
        }
    }
