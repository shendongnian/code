    public class Requirements
    {
        public string EventMessageUId { get; set; }
        public int ProjectId { get; set; }
        public string CreatedByUser { get; set; }
        public string CreatedByApp { get; set; }        
        public string CreatedOn { get; set; }
        public List<Message> Message {get;set;}  //add this
    }
