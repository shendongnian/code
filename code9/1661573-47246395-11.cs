     Dictionary<string, string> dict = new Dictionary<string, string>();
     XDocument doc = XDocument.Load(@"C:\Practice\test.xml", LoadOptions.PreserveWhitespace);
     Regex reg = new Regex(@"deqn(\d+)-(\d+)");
     var x = from y in doc.Descendants("disp-formula").ToList()
                    where reg.IsMatch(y.Attribute("id").Value)
                    select y.Attribute("id");
