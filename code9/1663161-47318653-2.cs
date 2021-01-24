    public class RootData
    {        
        public Dictionary<int, FoodItem> Choices { set; get; }
    }
    public class FoodItem
    {
        public int Id { get; set; }
        public int FoodPropertyId { get; set; }
        public string Name { get; set; }
    }
