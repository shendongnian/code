     public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
     string sXML = "<XML>"+
                            "<Properties>"+
                                "<Property name=\"ActionLogPrompt\">2</Property>"+
                                "<Property name=\"Answer\"></Property>"+
                                "<Property name=\"SubQBackColour\">#FF0000</Property>"+
                            "</Properties></XML>";
            XDocument doc3 = XDocument.Parse(sXML);
            var v4 = from p in doc3.Descendants("Property")
                     where p.Value == "#FF0000"
                     select new Property
                     {
                         Name = p.Attribute("name").Value,
                         Value = p.Value
                     };
            Console.WriteLine(v4.FirstOrDefault().Name);
