    class PQR
    {
        public event EventHandler MethodP;
        public event EventHandler MethodQ;
        public event EventHandler MethodR;
        public PQR()
        {
            MethodP += delegate { MethodP1(); };
            MethodQ += delegate { MethodQ1(); };
            MethodR += delegate { MethodR1(); };
        }
        private void MethodP1()
        {
            Console.WriteLine("In method P");
        }
        private void MethodQ1()
        {
            Console.WriteLine("In method Q");
        }
        private void MethodR1()
        {
            Console.WriteLine("In method R");
        }
    }
