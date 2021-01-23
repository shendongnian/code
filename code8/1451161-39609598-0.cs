    public class Table1
    {
    
          [ForeignKey("Table2_ID")]
          [Index("MultipleIndexColumn",1)]
          public virtual Table2  Table2 { get; set; }
          public int Table2_ID { get; set; }
        
          [ForeignKey("Table3_ID")]
          [Index("MultipleIndexColumn",2)]
          public virtual Table3  Table3 { get; set; }
          public int Table3_ID { get; set; }
        
          [Index("MultipleIndexColumn",3)]
          public DateTime CreateDateTime {get; set;}
        
        }
