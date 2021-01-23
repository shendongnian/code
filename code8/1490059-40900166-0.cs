    public class Customer
    {
        [JsonProperty("CUSTOMERNO")]
        public string CustomerNo { get; set; }
        [JsonProperty("BUSINESSAREA")]
        public string BusinessArea { get; set; }
        [JsonProperty("FIRSTNAME")]
        public string FirstName { get; set; }
        [JsonProperty("LASTNAME")]
        public string LastName { get; set; }
        [JsonProperty("GENDER")]
        public int Gender { get; set; }
    }
    public class Permission
    {
        [JsonProperty("EMAIL")]
        public string Email { get; set; }
        [JsonProperty("TYPE")]
        public string Type { get; set; }
        [JsonProperty("VALUE")]
        public int Value { get; set; }
        [JsonProperty("STATUS")]
        public string Status { get; set; }
        [JsonProperty("DATAORIGIN")]
        public string DataOrigin { get; set; }
        [JsonProperty("PERMISSIONDATE")]
        public string PermissionDate { get; set; }
        [JsonProperty("CHANGEDATE")]
        public string ChangeDate { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("CUSTOMER")]
        public Customer Customer { get; set; }
        [JsonProperty("PERMISSION")]
        public List<Permission> Permissions { get; set; }
    }
