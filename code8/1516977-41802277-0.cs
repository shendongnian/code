            public class Product
                {
                    [Key]
                    public int Id { get; set; }
                    public string OrderNum { get; set; }
                    public DateTime DateOfPurchased { get; set; }
                    public int CustomerId { get; set; }
                    public virtual ICollection<OrderedItem> OrderedItems { get; set; }
            
                }
                public class OrderedItem
                {
                    [Key]
                    public int Id { get; set; }
                    public int ProductId { get; set; }
                    public int? Quantity { get; set; }
                    public int? ItemId { get; set; }
                    public decimal? TotalPrice { get; set; }
                    public decimal? Profit { get; set; }
          
                    public virtual Product Product { get; set; }
                }
