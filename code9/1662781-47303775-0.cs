    public class ClassWithAllProperties
    {
        public int id { get; set; }
        public string device_code { get; set; }
        public string device_type { get; set; }
        public string authentication_token { get; set; }
        public string Status { get; set; }
    }
    var allInstances = new List<ClassWithAllProperties>();
    // populate list
    var allInstancesButNotAllProperties = allInstances.Select(x => new { id = x.id, authentication_token = x.authentication_token, Status = x.Status }).ToList();
