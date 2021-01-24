    public class FruitVM
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    public class ParentVM
    {
        public string TextField { get; set; }
        public List<FruitVM> Fruits { get; set; }
    }
