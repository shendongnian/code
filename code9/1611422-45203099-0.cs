    public class Material
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Increment { get; set; }
        public int Max { get; set; }
        public int Storage { get; set; }
        public StorageCost StorageCost { get; set; }
    }
    public class StorageCost
    {
        public int Stone { get; set; }
        public int Wood { get; set; }
    }
