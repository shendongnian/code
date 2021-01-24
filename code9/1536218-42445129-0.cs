    using System;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace MyNamespace
    {
        public class Config
        {
    
            public string SomeStringProperty { get; set; }
            public int SomeIntProperty { get; set; }
    
            private static string _filePath = null;
    
            static Config()
            {
                _filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData) + @"\My Program Name";
            }
    
            public static Config LoadConfig()
            {
                if (File.Exists(_filePath))
                {
                    try
                    {
                        XmlSerializer reader = new XmlSerializer(typeof(Config));
                        StreamReader file = new StreamReader(_filePath);
                        Config config = (reader.Deserialize(file) as Config);
                        return config;
                    }
                    catch (Exception ex)
                    {
                        //Deal With no file file read error here.
                    }
                }
    
                // IF we get here no valid config file was loaded so make a new one.
                return new Config();
    
            }
    
            public Exception SaveConfig()
            {
                try
                {
                    XmlSerializer writer = new XmlSerializer(typeof(Config));
                    StreamWriter file = new StreamWriter(_filePath);
                    writer.Serialize(file, this);
                    file.Close();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }
    }
