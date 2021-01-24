    public class Supplier : IRateable
    {
      public int Rating { get; set; }
    }
    
    public class Product : IRateable
    {
      // Get's the suppliers rating, tho, is this what you wanted?
      public int Rating => Supplier.Rating;
    
      public Supplier Supplier { get; set; }
    }
