    public class Order
    {
      public ICollection<Product> Items { get; set; }
      public decimal Discount { get; set; }
      public decimal ShippingCost { get; set; }
      public decimal Cost => Items?.Sum(p => p.Price) ?? 0 + ShippingCost + Discount;
    }
    public class Product
    {
      public string Title { get; set; }
      public decimal Price { get; set; }
    }
 
