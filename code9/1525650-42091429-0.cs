     private static void ReadXML2()
        {
            string sXML = "<messageTags>"+
                          "<tag key=\"35\" value=\"U1\" />"+
                          "<tag key=\"49\" value=\"GEMI1\" />"+
                          "<tag key=\"8\" value=\"FIX.4.1\" />"+
                          "<tag key=\"9\" value=\"732\" />"+
                        "</messageTags>";
            XDocument doc = XDocument.Parse(sXML);
            var v = (from p in doc.Descendants("tag")
                     select p).ToDictionary(item => item.Attribute("key").Value,item=> item.Attribute("value").Value);
            Console.WriteLine(v.Count());
        }
