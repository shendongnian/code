    public class Answer
    {
        public int Id { get; set; }
        public int? DisputeId { get; set; }
        //..
    
        public Dispute Dispute { get; set; }
        //..
    }
