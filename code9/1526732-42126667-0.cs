    public class InnerTemp
    {
       public int A { get; set; }
       public int B { get; set; }
       public int C { get; set; }
       public static InnerTemp Copy(InnerTemp source)
       {
          return new InnerTemp { A = source.A, B = source.B, C = source.C };
       }
    }
