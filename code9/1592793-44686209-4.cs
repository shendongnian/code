    public class Utility
    {
            public T FromXml<T>(String xml)
            {
                T returnedXmlClass = default(T);
    
                using (TextReader reader = new StringReader(xml))
                {                
                   returnedXmlClass = (T)new XmlSerializer(typeof(T)).Deserialize(new ExcelNameSpaceXmlTextReader(reader)); 
                } 
            
           
            return returnedXmlClass;
        }
    }
