    void Main()
    {
    	var res = JsonConvert.SerializeObject(InstallSoftwareMetadata.GetInstallSoftwareMetadata());
    }
    
    public class InstallSoftwareMetadata
    {
    
        [JsonProperty("sourceType")]
        public string SourceType { get; set; }
        [JsonProperty("toolInstance")]
        public string ToolInstance { get; set; }
        [JsonProperty("ticketDetail")]
        public TicketDetail TicketDetail { get; set; }
    
        public static InstallSoftwareMetadata GetInstallSoftwareMetadata()
        {
            var ticketDetail = new TicketDetail
            {
                Switch = "/easy",
                Number = Guid.NewGuid().ToString()
            };
    
            return new InstallSoftwareMetadata
            {
                SourceType = "rest1",
                ToolInstance = "rest1",
                TicketDetail = ticketDetail
            };
        }
    }
    
    public class TicketDetail
    {
    
        [JsonProperty("number")]
        public string Number { get; set; }
    
        [JsonProperty("Switch")]
        public string Switch { get; set; }
    
    }
