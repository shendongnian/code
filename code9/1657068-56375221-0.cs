    public class APIResultModel<T> where T: APIModel, new()
    {
        
        public string ImmutableProperty { get; set; }
        public T Result { get; set; }
        public APIResultModel<T> Deserialize(string json)
        {
            var jObj = JObject.Parse(json);
            T t = new T();
            var result = jObj[t.TypeName()];
            jObj.Remove(t.TypeName());
            jObj["Result"] = result;
            return jObj.ToObject<APIResultModel<T>>();
        }
    }
