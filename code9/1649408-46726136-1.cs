    public class MyRecord
    {
         [FieldFixedLength(5)] // for reading
         [FieldConverter(ConverterKind.Decimal, ".")] // for writing
         public decimal Foo{get; set; }
    }
