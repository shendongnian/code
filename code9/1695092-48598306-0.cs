    public class TestMethod
    {
        private string a, b, c, d, e;
    
        public TestMethod SetA(string text) { a = text; return this; }
        public TestMethod SetB(string text) { b = text; return this; }
        public TestMethod SetC(string text) { c = text; return this; }
        public TestMethod SetD(string text) { d = text; return this; }
        public TestMethod SetE(string text) { e = text; return this; }
    
        public void Print()
        {
            Console.WriteLine(string.Format("A: {0}\nB: {1}\nC: {2}\nD: {3}\nE: {4}\n", a,b,c,d,e));
        }
    }
