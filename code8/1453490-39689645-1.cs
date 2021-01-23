    #if net45
    System.Runtime.Serialization.Formatters.Binary;  
    public class BinaryFormatSerializer : ISerializer
    {
        public string Serialize(object obj)
        {
            var serializer = new BinaryFormatter();
            string binData = serializer.Serialize(obj);
            return new BinaryFormatter(binData).Format();
        }
    }
    #else // Below you would put whatever logic 
          // to not use 4.5 framework whenever 
          // BinaryFormatter is added to core
