    public static T ObjectToXML<T>(string xml) where T : class
            {
                T obj = null;
                try
                {
                    using(strReader = new StringReader(xml))
                    {
                      using (serializer = new XmlSerializer(typeof(T)))
                      {
                        using (xmlReader = new XmlTextReader(strReader))
                        {
                          obj = (T)serializer.Deserialize(xmlReader);
                        }
                      }
                    }
                }
                catch (Exception exp)
                {
                    //Handle Exception Code
                    var s = "d";
                }
    
                return obj;
            }
