    public class CarVM
    {
        public int? ID { get; set; }
        public string Description { get; set; }
        public List<GearVM> Gears { get; set; }
    }
    public class GearVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
