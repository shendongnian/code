    public class PromoItemProduct
    {
         public int ProductId { get; set; }
         public int PromoItemId { get; set; }
         public virtual Product Products { get; set; }
         public virtual PromoItem PromoItem { get; set; }
    }
