       static Dictionary<string, string> ele = new Dictionary<string, string>();
        private static void ReadAllElements(XElement node)
        {
            if (node.HasElements)
            {
                foreach (var element in node.Elements())
                    ReadAllElements(element);
            }
            else
            {
                ele[node.Name.ToString()] = node.Value;
                if (node.HasAttributes)
                {
                    foreach (var att in node.Attributes())
                        ele[node.Name.ToString() + att.Name.ToString()] = att.Value;
                }
                return;
            }
        }
    
        public static void Main()
        {
            FileStream fs = new FileStream("XMLFile1.xml", FileMode.Open);
            XDocument xDoc = XDocument.Load(fs);
            var rows=(from row in xDoc.Descendants("e1").Elements()
                         select row).ToList();
            foreach (XElement node in rows)
                ReadAllElements(node);
            foreach (var keypair in ele)
                Console.WriteLine($"{keypair.Key} : {keypair.Value}");
            Console.ReadLine();
     }
