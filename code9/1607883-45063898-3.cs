    public class BeverageData
    {
        public string Name { set; get; }
        public string Type { set; get; }
        public decimal Price { set; get; }
        public int Size { get; set; }
        public override string ToString()
        {
            return "Name: " + Name + ", Price: " + Price + ", Type: " + Type;
        }
    }
