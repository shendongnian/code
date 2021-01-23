    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    [IgnoreEmptyLines]
    public class OrdersFixed
        :INotifyRead
    {
       [FieldFixedLength(7)]
       public int OrderID;
       [FieldFixedLength(8)]
       public string CustomerID;
       [FieldFixedLength(8)]
       public DateTime OrderDate;
       [FieldFixedLength(11)]
       public decimal Freight;
      public void BeforeRead(BeforeReadEventArgs e)
      {
        if (e.RecordLine.StartsWith(" ") ||
           e.RecordLine.StartsWith("-"))
            e.SkipThisRecord = true;
      }
      public void AfterRead(AfterReadEventArgs e)
      {   
        //  we want to drop all records with no freight
        if (Freight == 0)
            e.SkipThisRecord = true;
      }
    }
