    public class RetornoConsumo
    {
        [JsonProperty("success")]
        public bool Processado { get; set; }
        [JsonProperty("data")]
        public Dictionary<string, Consumo> Registro { get; set; }
    }
