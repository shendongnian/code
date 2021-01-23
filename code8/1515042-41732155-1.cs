    [JsonConverter(typeof(TelemetryDataConverter))]
    public class telemetryData
    {
        public string ts { get; set; }
        public double temp { get; set; }
    }
