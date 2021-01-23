	public class NonPortable
    {
        [JsonProperty("NameOfGamingEquipments")]
        public string NameOfGamingEquipments { get; set; }
        [JsonProperty("ResourceId")]
        public int ResourceId { get; set; }
        [JsonProperty("RentalPrice")]
        public int RentalPrice { get; set; }
        [JsonProperty("DeliveryMode")]
        public string DeliveryMode { get; set; }
        [JsonProperty("quantityOfCables")]
        public int quantityOfCables { get; set; }
        [JsonProperty("TypeOfCable")]
        public string TypeOfCable { get; set; }
        [JsonProperty("Accessories")]
        public string Accessories { get; set; }
    }
    public class Portable
    {
        [JsonProperty("NameOfGamingEquipments")]
        public string NameOfGamingEquipments { get; set; }
        [JsonProperty("ResourceId")]
        public int ResourceId { get; set; }
        [JsonProperty("RentalPrice")]
        public int RentalPrice { get; set; }
        [JsonProperty("DeliveryMode")]
        public string DeliveryMode { get; set; }
        [JsonProperty("sizeOfScreen")]
        public string sizeOfScreen { get; set; }
        [JsonProperty("quantityOfCartridges")]
        public int quantityOfCartridges { get; set; }
        [JsonProperty("CartridgeName")]
        public string CartridgeName { get; set; }
        [JsonProperty("touchScreenFunction")]
        public bool touchScreenFunction { get; set; }
    }
    public class Rootobject
    {
        [JsonProperty("Non_Portable")]
        public IList<NonPortable> Non_Portable { get; set; }
        [JsonProperty("Portable")]
        public IList<Portable> Portable { get; set; }
    }
	
