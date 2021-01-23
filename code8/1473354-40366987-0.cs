    public class ProjectListItem
    {
        public int ProjectId { get; set; } // you need this field for identification and navigation
        public DateTime LastModifiedDate { get; set; }
        public int Rooms { get; set; }
    }
    public class RoomListItem
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public decimal TotalCost { get; set; }
    }
    public class RoomDetailsItem
    {
        public int RoomId { get; set; }
        public string Name { get; set; } // ok, that looks like you can select a base class for this models
        public int Area { get; set; }
        public ICollection<ProductModel> Products { get; set }
    }
    public class ProductModel
    {
        public string Name { get; set; }
        // public decimal BestPrice { get; set; } // you should not add this property because your "details" page not contained this info
        public int Quantity { get; set; }
    }
