    public class Order {
      public int OrderNr { get; set; }
      public string Custommer { get; set; }
      public string Material { get; set; }
      public string MaterialCode { get; set; }
      public List<OrderItem> OrderInfo { get; set; }
    
      public Order(int oNum, string oCust, string oMaterial, string oMatCode) {
        OrderNr = oNum;
        Custommer = oCust;
        Material = oMaterial;
        MaterialCode = oMatCode;
        OrderInfo = new List<OrderItem>();
      }
    
      public DataTable GetItemsDT() {
        DataTable OrderDT = new DataTable();
        OrderDT.Columns.Add("Length", typeof(double));
        OrderDT.Columns.Add("Width", typeof(double));
        OrderDT.Columns.Add("Qty", typeof(double));
        OrderDT.Columns.Add("Texture", typeof(string));
        foreach (OrderItem item in OrderInfo) {
          OrderDT.Rows.Add(item.Lenght, item.Width, item.Qty, item.Texture);
        }
        return OrderDT;
      }
    
      public string GetOrderString() {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Order: " + OrderNr + " Customer: " + Custommer + " Material: " + Material + " MatCode: " + MaterialCode);
        sb.AppendLine("-- Order Items --");
        sb.AppendLine("Length, Width, Qty, Texture");
        foreach (OrderItem item in OrderInfo) {
          sb.AppendLine(item.Lenght + ", " + item.Width + ", " + item.Qty + ", " + item.Texture);
        }
        sb.AppendLine("");
        return sb.ToString();
      }
    }
