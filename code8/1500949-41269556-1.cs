    namespace XmlSerialization
    {
    	class Program
    	{
    		static string ToXmlString<T>(T t)
    		{
    			var serializer = new XmlSerializer(t.GetType());
    			using (var sw = new System.IO.StringWriter())
    			{
    				serializer.Serialize(sw, t);
    				return sw.ToString();
    			}
    		}
    		static void Main(string[] args)
    		{
    			var c = new component { section = new section { title = "Reason for Visit", text = new text { content = new content { ID = "ID3EZZKACA", text = "No Reason for Visit was given." } } } };
    
    			string s = ToXmlString(c);
    		}
    	}
    }
