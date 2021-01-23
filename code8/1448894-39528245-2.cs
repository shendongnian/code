    public class PortalClass
    {
        public ApplicationModel applicationModel { get; set; }
        public string user_id { get; set; }
        public string id { get; set; }
        public object pageCollection { get; set; }
    }
    public object GetApplication(PortalClass data)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, PreserveReferencesHandling = PreserveReferencesHandling.None };
        var myObject=JsonConvert.DeserializeObject<PageCollection>(data.pageCollection.ToString(), settings)
        return null;
    }
