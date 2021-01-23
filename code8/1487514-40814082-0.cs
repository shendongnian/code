    public class BaseModel<T>
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    
        public T FromString<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
