    public class InventoryJsonObject
    {
        public string sys_id { get; set; }
        public string dv_model_id { get; set; }
        public string due { get; set; }
        public string assigned_to { get; set; }
        public string dv_assigned_to { get; set; }
        [JsonProperty("assigned_to.phone")]
        public string assigned_to_phone { get; set; }
        [JsonProperty("assigned_to.email")]
        public string assigned_to_email { get; set; }
        public string u_borrower_id { get; set; }
        public string dv_u_borrower_id { get; set; }
        [JsonProperty("u_borrower_id.phone")]
        public string u_borrower_id_phone { get; set; }
        [JsonProperty("u_borrower_id.email")]
        public string u_borrower_id_email { get; set; }
    }
