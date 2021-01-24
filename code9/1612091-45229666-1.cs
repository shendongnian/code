    public static void GetXmlData() 
        {
            config = new ConfigParameters(); //global scope var
            try
            {
                if (File.Exists("C:/path/config.xml"))
                {
                    String xmlDoc = XDocument.Load("C:/path/config.xml").ToString();
                    XmlSerializer serializer = new 
    XmlSerializer(typeof(ConfigParameters));
                    using (TextReader reader = new StringReader(xmlDoc))
                    {
                        mainForm.config = 
    (ConfigParameters)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
