    // Code in Assembly B:
    public class B { protected class P {} }
    
    // Code in Assembly D (references assembly B)
    class D1 : B { 
      public static object M() { return new { X = new B.P() }; }
    }
    class D2 : B { 
      public static object M() { return new { X = new B.P() }; }
    }
