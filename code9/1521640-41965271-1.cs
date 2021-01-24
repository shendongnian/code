    public  class ShinyClass
    {
        class InnerVar
        {
            public static Random r = new Random();
        }
    
        decimal d1 = InnerVar.r.Next();
        decimal d2 = InnerVar.r.Next();
        decimal d3 = InnerVar.r.Next();
    
        public override string ToString()
        {
            return d1 + " " + d2 + " " + d3;
        }
    }
