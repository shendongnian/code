    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MyDBExtensionClass
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fid", Required = Newtonsoft.Json.Required.Default)]
        public int FID { get; set; }
    
        public MyDBExtensionClass(int fid)
        {
            FID = fid;
        }
    }
