    namespace Project.Extensions
    {
    	public static class XmlSerialiserExtensions
    	{
    		public static void Serialise(this XmlSerializer serialiser, byte[] bytes, object obj)
    		{
    			using(var temp = new MemoryStream(bytes))
    				serialiser.Serialize(temp, obj);
    		}
    
    		public static object Deserialise(this XmlSerializer serialiser, byte[] bytes)
    		{
    			using(var temp = new MemoryStream(bytes))
    				return serialiser.Deserialize(temp);
    		}
    	}
    }
