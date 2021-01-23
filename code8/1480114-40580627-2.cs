    public class Application
    {
        [JsonProperty("App_ID")]
        public int App_ID { get; set; }
        [JsonProperty("App_Ref")]
        public string App_Ref { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Error_Code")]
        public int? Error_Code { get; set; }
        [JsonProperty("Error_Message")]
        public string Error_Message { get; set; }
        [JsonProperty("Create_Dt")]
        public string Create_Dt { get; set; }
        [JsonProperty("Modify_Dt")]
        public string Modify_Dt { get; set; }
        [JsonProperty("Client_Name")]
        public string Client_Name { get; set; }
        [JsonProperty("Client_Code")]
        public string Client_Code { get; set; }
        [JsonProperty("Centrelink_Status")]
        public string Centrelink_Status { get; set; }
    }
    public class Response
    {
        [JsonProperty("Applications")]
        public IList<Application> Applications { get; set; }
        [JsonProperty("Current_Dt")]
        public string Current_Dt { get; set; }
        [JsonProperty("Last_App_Dt")]
        public string Last_App_Dt { get; set; }
        [JsonProperty("Count")]
        public int Count { get; set; }
        [JsonProperty("Total")]
        public int Total { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("Success")]
        public bool Success { get; set; }
        [JsonProperty("Response")]
        public Response jsonResponse { get; set; }
    }
