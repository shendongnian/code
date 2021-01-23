      [Serializable]
      public class Gender
    {
    
        [XmlElement("Item")]
        public List<Item> GenderList = new List<Item>();
    }
    
    
    public class Item
    {
        [XmlElement("CODE")]
        public string Code { get; set; }
    
        [XmlElement("DESCRIPTION")]
        public string Description { get; set; }
    }
     public static T Deserialize<T>(string input) where T : class
            {
                Log.Debug("Deserialize" + typeof(T).Name, "xml string Deserialize ediliyor" + Environment.NewLine + input);            
    
                XmlSerializer ser = new XmlSerializer(typeof(T), "SetDefaultNamespace"); // optinal parameters DefaultNamespace
                using (StringReader sr = new StringReader(input))
                {
                    var desearializedObject = (T)ser.Deserialize(sr);
                    Log.Debug("Deserialize" + typeof(T).Name, "Obje Deserialize işlemi tamamlandı");
                    return desearializedObject;
                }
            }
    
    
        Deserialize<Gender>(xmlString);
