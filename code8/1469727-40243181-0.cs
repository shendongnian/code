    class PQR
    {
        public event EventHandler MethodP;
        public event EventHandler MethodQ;
        public event EventHandler MethodR;
        public PQR()
        {
            MethodP += delegate { Console.WriteLine("In method P"); };
            MethodQ += delegate { Console.WriteLine("In method Q"); };
            MethodR += delegate { Console.WriteLine("In method R"); };
        }
    }
