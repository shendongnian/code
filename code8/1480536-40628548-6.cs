            public class Appointment
            {
                [JsonProperty("doctor")]
                public string Doctor { get; set; }
    
                [JsonProperty("slot")]
                public int Slot { get; set; }
                
                [JsonProperty("date")]
                public DateTime Date { get; set; }
            } 
