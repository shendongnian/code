    public class Inventory
    {
        public ProductDetails[] Products { get; set; }
    }
    var inventory = JsonConvert.DeserializeObject<Inventory>(result);
