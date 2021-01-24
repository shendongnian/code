    public  class ShinyClass
    {
        public class InnerVar
        {
            public static Random r = new Random();
        }
    
        private decimal d1 = InnerVar.r.Next();
        private decimal d2 = InnerVar.r.Next();
        private decimal d3 = InnerVar.r.Next();
    
        public override string ToString()
        {
            return d1 + " " + d2 + " " + d3;
        }
    }
