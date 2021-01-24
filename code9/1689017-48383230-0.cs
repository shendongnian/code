    public class VehicleGO
    {
        [JsonProperty(PropertyName = "placa")]
        public string Plate { get; set; }
        [JsonProperty(PropertyName = "categoriz")]
        public string Category { get; set; }
    }
    
    public class Vehicles
    {
        public List<Veiculo> veiculo { get; set; }
    }
