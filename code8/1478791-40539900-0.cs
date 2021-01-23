    public class Application
    {
        public int App_ID { get; set; }
        public string App_Ref { get; set; }
        public string Status { get; set; }
        public int? Error_Code { get; set; } // Or string, if not numeric
        public string Error_Message { get; set; }
        public DateTime Create_Dt { get; set; }
        public DateTime Modify_Dt { get; set; }
        public string Client_Name { get; set; }
        public string Client_Code { get; set; }
        public string Centrelink_Status { get; set; }
    }
