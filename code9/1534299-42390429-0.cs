    public enum MetaStatus
    {
        SUCCESS
        // FAILURE,
        // ... etc
    }
    
    public class Meta
    {
        public MetaStatus Status { get; set; }
        public long Count { get; set; }
    }
    
    public class ApiResponse
    {
        [JsonProperty("_meta")]
        public Meta Meta { get; set; }
    
        [JsonProperty("result")]
        public JToken JsonResult { get; set; }
    
        public T GetResultAs<T>()
        {
            // put in place some error handling logic, depending upon what's really an error
            // in this method.
            try
            {
                return JsonResult.ToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }
    }
