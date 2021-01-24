    [Table("ShopProductGraphic")]
    public class ProductGraphic : Base
    {
        public int ProductId { get; set; }
        public int GraphicId { get; set; }
        public virtual Graphic Graphic { get; set; }
        public virtual Product Product {get; set;}
    }
