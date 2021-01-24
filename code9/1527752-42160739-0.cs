    public class Example<TA, TB, TC, TD> 
    {
      public TA PropA { get; set; }
      public TB PropB { get; set; }
      public TC PropC { get; set; }
      public TD PropD { get; set; }
      
      public Example<T1, T2, Object, Object> Case1Factory<T1, T2>(T1 a, T2 b)
      {
        return new Example<T1, T2, Object, Object>()
        {
          PropA = a,
          PropB = b
        };
      }
      public Example<object, object, T3, T4> Case2Factory<T3, T4>(T3 c, T4 d)
      {
        return new Example<Object, Object, T3, T4>()
        {
          PropC = c,
          PropD = d
        };
      }
    }
