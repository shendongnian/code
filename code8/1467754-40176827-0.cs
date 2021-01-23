    public class C {
      // accepted
      public void f([Optional, DefaultParameterValue(1)] object i) { }
      // error CS1763: 'i' is of type 'object'. A default parameter value of a reference type other than string can only be initialized with null
      //public void g(object i = 1) { }
      // works, calls f(1)
      public void h() { f(); }
    }
