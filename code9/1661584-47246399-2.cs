    Dictionary<string, string> dict = new Dictionary<string, string>();
    
    var regex = new Regex(@"deqn(\d+)-(\d+)");
    
    XDocument doc = XDocument.Load(@"D:\Practice\test.xml", LoadOptions.PreserveWhitespace);
    var x = from y in doc.Descendants("disp-formula")
            let m = regex.Match(y.Attribute("id").Value)
            where m.Success
            select m;
    
    
    foreach (var item in x)
    {
        var from = int.Parse(item.Groups[1].Value);
        var to = int.Parse(item.Groups[2].Value);
        for (int i = from; i < to; i++)
            dict.Add("deqn" + i, item.Value);
    }
