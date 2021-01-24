    public class MemMainS
    {
        private Dictionary<string, sValues> data = new Dictionary<string, sValues>();
        public ICollection[string] Keys {get {return data.Keys;} }
        public Dictionary<string, sValues>.ValueCollection.Enumerator GetEnumerator()
        {
            return data.Values.GetEnumerator();
        }
        public sValue this[string valueName] 
        {
            get 
            {
                if (data.ContainsKey(valueName)) return data[valueName];
                return default(sValue);
            }
            set 
            {
                data[valueName] = value;
            }
        }
        public sValues svMode {get {return data["svMode"]; } set {data["svMode"] = value;} }
        public sValues svFreqOrBal {get {return data["svFreqOrBal "]; } set {data["svFreqOrBal "] = value;} };
       // (...)
    }
