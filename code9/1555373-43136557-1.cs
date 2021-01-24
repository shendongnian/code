    var json1 = "[{\"place\":{\"first\":\"1\",\"second\":\"2\",\"third\":\"3\"}},{\"place\":{\"first\":\"11\",\"second\":\"22\",\"third\":\"33\"}},{\"place\":{\"first\":\"111\",\"second\":\"222\",\"third\":\"333\"}}]";
            XmlDocument deserializeXmlNode;
            if (json1.IndexOf("[", StringComparison.OrdinalIgnoreCase) == 0)
            {
                deserializeXmlNode = Newtonsoft.Json.JsonConvert.DeserializeXmlNode($"{{\"items\":{json1}}}", "source");
            }
            else
            {
                deserializeXmlNode = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json1, "source");
            }
            Console.WriteLine(deserializeXmlNode.OuterXml);
            Console.ReadKey();
