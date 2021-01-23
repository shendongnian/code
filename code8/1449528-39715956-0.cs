    [XmlRoot("MyFruit")]
    public class MyFruit : List<Fruit>
    {
    }
    
    public class Fruit
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
    }
