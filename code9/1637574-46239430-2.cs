    private static T Deserialize<T>(string json)
        {
            T unsecureResult;
           string _DateTypeFormat = "yyyy-MM-dd HH:mm:ss";
            DataContractJsonSerializerSettings serializerSettings = new DataContractJsonSerializerSettings();
            DataContractJsonSerializer serializer;
            MemoryStream ms;
            unsecureResult = default(T);
            serializerSettings.DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat(_DateTypeFormat);
            serializer = new DataContractJsonSerializer(typeof(T));
            ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            unsecureResult = (T)serializer.ReadObject(ms);
            return unsecureResult;
        }
