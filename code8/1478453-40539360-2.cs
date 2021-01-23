    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        [JsonProperty("Address")]
        JToken AddressToken { get; set; }
        [JsonIgnore]
        public string Address
        {
            get
            {
                if (AddressToken == null)
                    return null;
                return AddressToken.ToString(Formatting.Indented); // Or Formatting.None if you prefer
            }
            set
            {
                if (value == null)
                    AddressToken = null;
                else
                    // Throw an exception if value is not valid JSON.
                    AddressToken = JToken.Parse(value);
            }
        }
    }
