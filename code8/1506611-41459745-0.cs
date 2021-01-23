    public struct Color
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int this[int index]
        {
             get
             {
                 switch(index)
                 {
                     case 0: return R;
                     case 1: return G;
                     case 2: return B;
                 }
                 throw new IndexOutOfRangeException();
             }
         }
    }
