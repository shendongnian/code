     public class StampForm
        {
            public string ReqNo { get; set; }
            public string SabtDate { get; set; }
            public string FlightRef { get; set; }
            public string HotelRef { get; set; }
            public string ConfirmUser { get; set; }
    
            [JsonProperty("confirmUser")]
            public JObject User { get; set; }
       ..........
    }
