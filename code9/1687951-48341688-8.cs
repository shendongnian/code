    public class MyData
    {
      public decimal Val1 { get; set; }
      public decimal Val2 { get; set; }
      [IgnoreIfValueExactly(0)]
      public decimal Val3 { get; set; }
    }
