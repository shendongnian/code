        [Table("widgets")]
        class Widget 
       {
          [Key, Column("id")]
          int Id { get; set; }
        
          [Column("referencenumber")]
          int? ReferenceNumber { get; set; }
        
          [ForeignKey("ReferenceNumber")]
          public virtual WidgetReferenceData ReferenceData // ???? How do I express this?
        }
        
        [Table("widgetreferences")]
        class WidgetReference 
        {
          [Key, Column("referencenumber")]
          int ReferenceNumber { get; set; }
        
          [Column("value")]      
          string Value { get;set; }
        }
