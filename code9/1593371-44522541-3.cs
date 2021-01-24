    private void DeSerialize()
        {
            try
            {
                if (File.Exists(@"D:\Test_Jun13.xml"))
                {
                    var deserializer = new XmlSerializer(typeof(A));
                    using (TextReader reader = new StreamReader(@"D:\Test_Jun13.xml"))
                    {
                        var obj = deserializer.Deserialize(reader);
                        a = (A)obj;
                    }
                }
            }
            catch
            {
    
            }
    
    
        }
