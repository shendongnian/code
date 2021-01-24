    public partial class auctions
    {
      public int id { get; set; }
      public int lastDataId { get; set;}
      public virtual ICollection<auction_data> auction_data { get; set; }
    }
