    static void Main(string[] args)
    {
        var data = Deserialize();
        //do your logic on normal object
        Serialize(data);
        
        
    }
    
    static root Deserialize()
    {
        using (var file = File.Open("test.txt", FileMode.Open))
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "root";
            xRoot.IsNullable = true;
            var xmlSerializer = new XmlSerializer(typeof(root), xRoot);
            return (root)xmlSerializer.Deserialize(file);
        }
    }
    
    static void Serialize(root data)
    {
        using (var file = File.Create("result.txt"))
        {
            var xmlSerializer = new XmlSerializer(typeof(root));
            xmlSerializer.Serialize(file, data);
        }
    }
