    [DataContract]
    [JsonObject]
    public abstract class documentbase
    {
        [DataMember]
        [JsonProperty]
        public int id { get; set; }
        [DataMember]
        [JsonProperty]
        public string type { get; set; }
        [IgnoreDataMember]
        [JsonProperty("content")]
        public abstract JToken JsonContent { get; set; }
        [JsonIgnore]
        [DataMember(Name = "content")]
        string DataContractContent
        {
            get
            {
                if (JsonContent == null)
                    return null;
                return JsonContent.ToString(Newtonsoft.Json.Formatting.None);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    JsonContent = null;
                else
                    JsonContent = JToken.Parse(value);
            }
        }
    }
    [DataContract]
    [JsonObject]
    public class document : documentbase
    {
        JToken content;
        public override JToken JsonContent { get { return content; } set { content = value; } }
    }
    [DataContract]
    [JsonObject]
    public class document<T> : documentbase where T : class
    {
        [IgnoreDataMember]
        [JsonIgnore]
        public T Content { get; set; }
        public override JToken JsonContent
        {
            get
            {
                if (Content == null)
                    return null;
                return JToken.FromObject(Content);
            }
            set
            {
                if (value == null || value.Type == JTokenType.Null)
                    Content = null;
                else
                    Content = value.ToObject<T>();
            }
        }
    }
