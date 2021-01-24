    class Apartment
    {
        public int BuildingNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public int Type { get; set; }
        public int View { get; set; }
        public string Name { get; set; }
    
        public override string ToString()
        {
           return $"{BuildingNumber} {ApartmentNumber} {Type} {View} {Name}";
        }
    }
