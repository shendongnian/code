    Public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
    
    
        public virtual ICollection<Refund> Refund { get; set; }
    
    }
