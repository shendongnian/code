    public class Car
    {
        public string CarBrand { get; set; }
        [JsonConverter(typeof(SteeringWheelJsonConverter))]
        public ISteeringWheel SteeringWheel { get; set; }
    }
