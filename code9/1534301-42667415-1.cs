    public class ApiReturn
    {
        [JsonProperty("_meta")]
        public ApiMeta Meta { get; set; }
        [JsonProperty("result")]
        public JToken Result { get; set; }
        public T GetResultAs<T>() where T : new()
        {
            var objectReturned = default(T);
            try
            {
                if (Result.Type == JTokenType.Array)
                {
                    objectReturned = Result.ToObject<T>();
                }
                else if (Result.Type == JTokenType.Object)
                {
                    objectReturned = new T();
                }
            }
            catch
            {
                objectReturned = new T();
            }
            return objectReturned;
        }
    }
