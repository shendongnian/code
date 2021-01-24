     var v2 = (from p in doc.Descendants("tag")
                     select p);
            string sOutput = "";
            foreach (var item in v2)
            {
                sOutput += item.Attribute("key").Value + "=" + item.Attribute("value").Value;
            }
            Console.WriteLine(sOutput);
