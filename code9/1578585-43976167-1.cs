    public class Rootobject
    {
        [JsonProperty("usr_id")]
        public string UserId { get; set; }
        [JsonProperty("patient_id")]
        public string PatientId { get; set; }
        [JsonProperty("executions ")]
        public Execution[] Executions { get; set; }
    }
    
    public class Execution
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("datee")]
        public DateTime Date { get; set; }
        [JsonProperty("delete")]
        public bool Delete { get; set; }
    }
