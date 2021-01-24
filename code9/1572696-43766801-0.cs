    public class SocioEconomicStudy : BaseModel
    {
        public string Folio { get; set; }
        public string Craft { get; set; }
        [JsonProperty("request_type")]
        public string RequestType { get; set; }
    }
