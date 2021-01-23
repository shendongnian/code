    public class NameObjectConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new Type[] { typeof(NameObject) }; }
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            NameObject nameObj = new NameObject();
            string singleName = GetValue<string>(dictionary, "name");
            if (singleName != null)
            {
                nameObj.Name = singleName;
            }
            else
            {
                ArrayList arrayList = GetValue<ArrayList>(dictionary, "name");
                nameObj.Names = (arrayList != null) ? arrayList.Cast<string>().ToArray() : null;
            }
            return nameObj;
        }
        private T GetValue<T>(IDictionary<string, object> dict, string key)
        {
            object value = null;
            dict.TryGetValue(key, out value);
            return value != null && typeof(T).IsAssignableFrom(value.GetType()) ? (T)value : default(T);
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            NameObject nameObj = (NameObject)obj;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (nameObj.Names != null && nameObj.Names.Length == 1)
            {
                dict.Add("name", nameObj.Name);
            }
            else
            {
                dict.Add("name", nameObj.Names);
            }
            return dict;
        }
    }
