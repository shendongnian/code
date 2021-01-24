    [Table("Relations", Schema = "dbo")]
    public class Relations
    {
    
        public Relations()
        {
        }
        [Key, Column(Order = 1)] 
        public Guid GenRelRefNo {get; set;}
        
        [ForeignKey("EntityColumnToRefNo")]
        public Attribute EntityColumnTo { get; set; }
    
        [ForeignKey("EntityColumnFromRefNo")]
        public Attribute EntityColumnFrom { get; set; }
    
        public Guid EntityColumnToRefNo { get; set; }
        public Guid EntityColumnFromRefNo { get; set; }
        
        public string  CollaborationCaption {get; set;}
        public string  CollaborationTooltip {get; set;}
    }
