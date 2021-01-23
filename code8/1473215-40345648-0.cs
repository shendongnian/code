    public class AgencyNoteAttachment
    {        
        [Key]
        public int aut_id { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; } 
        [ForeignKey("AgencyNote")]       
        public int AgencyNoteId { get; set; }
       
        public virtual AgencyNote AgencyNote { get; set; }        
    }
