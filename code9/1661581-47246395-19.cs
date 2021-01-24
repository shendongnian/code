    int counter = 0;
    Dictionary<string, string> dict = new Dictionary<string, string>();
    XDocument doc = XDocument.Load(@"C:\Practice\test.xml", LoadOptions.PreserveWhitespace);
    Regex reg = new Regex(@"deqn(\d+)-(\d+)");
    (from y in doc.Descendants("disp-formula").ToList()
             where reg.IsMatch(y.Attribute("id").Value)
             select y.Attribute("id")).ToList().ForEach(item=>
              {
                  
                if (counter == 0)
                     counter = Convert.ToInt16(new Regex(@"\d+$").Match(item.Value.Split('-')[0]).Value) - 1;
                     dict.Add("deqn" + (++counter).ToString(), item.Value);
    });
