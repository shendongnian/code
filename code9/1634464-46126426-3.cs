    class Program
    {
        static void Main(string[] args)
        {
            C<int> c1 = new C<int>();
            C<bool> c2 = new C<bool>();
        
            c1.M();
            c2.M();
            c2.M();
            C.ReportCounts();
        }
    }
