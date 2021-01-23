        public static void ParseXml()
        {
            string fileName = "File.xml";
            XDocument xdoc = XDocument.Load(fileName);
            using (TextReader reader = new StringReader(xdoc.ToString()))
            {
                try
                {
                    var settings = (Settings)new XmlSerializer(typeof(Settings)).Deserialize(reader);
                }
                catch (Exception ex)
                {
                    // Handle exceptions as you see fit
                }
            }
        }
