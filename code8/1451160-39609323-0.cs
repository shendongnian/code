    public class Table1
    {
    
      public Table2 Table2Ref {get; set;}
    
      public Table3 Table3Ref {get; set;}
    
      [Index("MultipleIndexColumn",3)]
      public DateTime CreateDateTime {get; set;}
    
      [Index("MultipleIndexColumn",1)]
      public int Table2Id {get; set;}
      [Index("MultipleIndexColumn",2)]
      public int Table3Id {get; set;}
    }
