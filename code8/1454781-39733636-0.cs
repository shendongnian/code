    class Rings
    {
        public string Maker { set; get; }
        public string Name { set; get; }
        public string Metal { set; get; }
        public double Weight { set; get; }
        public float Size { set; get; }
        public string Purity { set; get; } //I don't know what this is... An int?
        public decimal Price { set; get; }
        public Rings() { }
        public Rings(string maker, string name, string metal, double weight, float size, string purity, decimal price)
        {
            Maker = maker;
            Name = name;
            Metal = metal;
            Weight = weight;
            Size = size;
            Purity = purity;
            Price = price;
        }
    }
