    [Table("Requests")]
    public class Request
    {
        [Key]
        public Guid Id { get; set; }
    
        public Guid ProductId { get; set; }
    
    
        public virtual int StartPositionId { get; set; }
    
        public virtual int DestinationPositionId { get; set; }
    
        [ForeignKey("StartPositionId")]
        public virtual Position StartPosition { get; set; }
    
        [ForeignKey("DestinationPositionId")]
        public virtual Position DestinationPosition { get; set; }
    }
    
    
    [Table("Positions")]
    public class Position
    {
        [Key]
        public int Id { get; set; }
    
        public double X { get; set; }
    
        public double Y { get; set; }
    
        public virtual ICollection<Request> StartPositionRequests { get; set; }
    
        public virtual ICollection<Request> DestinationPositionRequests { get; set; }
    
        public Position()
        {
            StartPositionRequests = new List<Request>();
            DestinationPositionRequests = new List<Request>();
        }
    }
