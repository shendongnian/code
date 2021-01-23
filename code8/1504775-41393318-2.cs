    public class NonPortable
    {
        public string NameOfGamingEquipments { get; set; }
        public int ResourceId { get; set; }
        public int RentalPrice { get; set; }
        public string DeliveryMode { get; set; }
        public int quantityOfCables { get; set; }
        public string TypeOfCable { get; set; }
        public string Accessories { get; set; }
    }
    public class Portable
    {
        public string NameOfGamingEquipments { get; set; }
        public int ResourceId { get; set; }
        public int RentalPrice { get; set; }
        public string DeliveryMode { get; set; }
        public string sizeOfScreen { get; set; }
        public int quantityOfCartridges { get; set; }
        public string CartridgeName { get; set; }
        public bool touchScreenFunction { get; set; }
    }
    public class RootObject
    {
        public List<NonPortable> Non_Portable { get; set; }
        public List<Portable> Portable { get; set; }
    }
