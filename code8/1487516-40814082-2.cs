    public class BaseModel
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    
        public BaseModel FromString(string str)
        {
            var type = this.GetType();
            var method = typeof(JsonConvert)
               .GetMethods()
            .FirstOrDefault(x => 
              x.Name == "DeserializeObject" 
              && x.IsGenericMethod 
              && x.GetParameters().Count() == 1).MakeGenericMethod(type);
            method.Invoke(null, new object[] { str });
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
