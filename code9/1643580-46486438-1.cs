    public static class Extensions
    {
        public static ScrewyAPIRequest GetRequest<T>(this T obj)
        {
            ScrewyAPIRequest _screwy = new ScrewyAPIRequest();
            
            var test= obj.GetType().GetProperties();
            foreach (var prop in obj.GetType().GetProperties())
            {
                _screwy.Fields[prop.Name] = prop.GetValue(obj, null);
            }
            return _screwy;
        }
    }
