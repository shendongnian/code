    public class YourEntity
    {
     [Column(Order = 0), Key, ForeignKey("FieldFromAnotherTable_1")]
     public int FieldFromAnotherTable_1_ID { get; set; }
     [Column(Order = 1), Key, ForeignKey("FieldFromAnotherTable_2")]
     public int FieldFromAnotherTable_2_ID { get; set; }
     public virtual Type1 FieldFromAnotherTable_1{ get; set; }
     public virtual Type2 FieldFromAnotherTable_2{ get; set; }
    }
