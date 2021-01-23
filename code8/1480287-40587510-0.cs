    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.Runtime.Serialization.Json;
    ...
    [DataContract]
    public class CardTextModel
    {
        [DataMember]
        public string prod_Code { get; set; }
        [DataMember]    
        public string page1Text { get; set; }
        [DataMember]
        public string insideText { get; set; }
        [DataMember]
        public string userName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> exportDate { get; set; }
    }
    [DataContract]
    public class CardTextModelRootObject
    {
        [DataMember]
        public List<CardTextModel> data {get; set; }
    }
    ...
        private T parseJSON<T>(string content)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(content);
                    writer.Flush();
                    stream.Position = 0;
                    DataContractJsonSerializer JSONSer = new DataContractJsonSerializer(typeof(T));
                    return (T)JSONSer.ReadObject(stream);
                }
            }
        }
    
    ...
    var deserializedJSONobj = parseJSON<CardTextModelRootObject>(content);
    ...
    
