    public class Record
    {
        [JsonExtensionData]
        public Dictionary<string, object> Data { get; set; }
        [JsonIgnore]
        public string Email
        {
            get { return GetDataValue(KnownRecordField.Email); }
            set { Data[KnownRecordField.Email] = value; }
        }
        [JsonIgnore]
        public string FirstName
        {
            get { return GetDataValue(KnownRecordField.FirstName); }
            set { Data[KnownRecordField.FirstName] = value; }
        }
        // use this method to avoid an exception if the well-known value
        // isn't present in the dictionary
        private string GetDataValue(string key)
        {
            object value;
            return Data.TryGetValue(key, out value) && value != null ? value.ToString() : null;
        }
    }
    public static class KnownRecordField
    {
        public static readonly string Email = "f_EMail";
        public static readonly string FirstName = "f_FirstName";
    }
