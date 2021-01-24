    public class OrderItem {
      public double Lenght { get; set; }
      public double Width { get; set; }
      public double Qty { get; set; }
      public string Texture { get; set; }
    
      public OrderItem(double inLength, double inWidth, double inQty, string inTexture) {
        Lenght = inLength;
        Width = inWidth;
        Qty = inQty;
        Texture = inTexture;
      }
    }
