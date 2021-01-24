    public class ItemModel
    {
        [Key]
        public int ItemModelId { get; set; }
    
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateCreatedUtc { get; set; }
    
        ...
    
        public virtual ICollection<BidModel> ItemBids { get; set; }
        [NotMapped]
        public BidModel AcceptedBid
        {
            get {
                return ItemBids.Where(s => s.Accepted).SingleOrDefault();
            }
            set {}
        }
    }
    
    public class BidModel
    {
        [Key]
        public int BidModelId { get; set; }
    
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateCreatedUtc { get; set; }
        public bool Accepted { get; set; }
    
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "The bid must have a positive value")]
        public int Bid { get; set; }
    
        [ForeignKey("ItemModel")]
        public int ItemModelId { get; set; }
    
        public virtual ItemModel ItemModel { get; set; }
    }
