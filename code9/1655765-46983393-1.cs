        static void Main(string[] args)
        {
            string value = ParseXML("EmailFromAddress");
            Console.WriteLine(value);
        }
        private static string ParseXML(string name)
        {
            // Load Document use 'XDocument.Parse' if you want to load the document from string
            XDocument xmlDoc = XDocument.Load("C:\\t\\2.txt");
            // Select element setting where name attribute is equal to name
            var node = xmlDoc
                .Descendants("WebApptNotificationService.Properties.Settings")
                .Elements("setting")
                .FirstOrDefault(x => (string) x.Attribute("name") == name);
            return node.Value;
        }
