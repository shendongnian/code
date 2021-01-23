    public class MasterEmailSettings
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string EmailAddress { get; set; }
        public static MasterEmailSettings Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MasterEmailSettings>(json);
        }
    }
