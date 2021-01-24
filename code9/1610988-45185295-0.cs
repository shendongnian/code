    public static IEnumerable<Setting> LoadSettings(string fileName)
    {
        try
        {
            var xml = new XmlDocument();
            xml.Load(fileName);
            var userNodes = xml.SelectNodes("/settings");
    
            foreach (XmlNode node in userNodes)
            {
                Setting globals = new Setting();
                globals.username = node.SelectSingleNode("username").InnerText;
                globals.password = node.SelectSingleNode("password").InnerText;
                globals.rank = node.SelectSingleNode("rank").InnerText;
    
                yield return globals;
            }
        }
        catch
        {
            Console.WriteLine("Oops, something is wrong.");
        }
    }
