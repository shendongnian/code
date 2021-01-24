       public class X
    { }
    
    public class Xi : X
    {
        public int I { get; }
        public Xi(int i) { I = i; }
        public static implicit operator Xi(int i) { return new Xi(i); }
    }
    
    public class L<T> : X where T : X
    {
        public L(params T[] values) { }
    
       public static void Main()
       {
           var test1 = new L<Xi>(1, 2, 3); // OK
           var test2 = new L<Xi>(new int[] { 1, 2, 3 }); // Unable to convert int[] into Xi
       }
    }
