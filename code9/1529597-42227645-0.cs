     string sXML = "<XML>"+
                            "<Properties>"+
                                "<Property name=\"ActionLogPrompt\">2</Property>"+
                                "<Property name=\"Answer\"></Property>"+
                                "<Property name=\"SubQBackColour\">#FF0000</Property>"+
                            "</Properties></XML>";
            XDocument doc3 = XDocument.Parse(sXML);
            var v= from p in doc3.Descendants("Property")
                           where p.Value == "#FF0000"
                               select p.Attribute("name").Value;
            Console.WriteLine(v);
