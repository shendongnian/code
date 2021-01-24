    XDocument doc = XDocument.Load(@"D:\Practice\test.xml", LoadOptions.PreserveWhitespace);
    var x = from y in doc.Descendants("disp-formula")
            let m = regex.Match(y.Attribute("id").Value)
            where m.Success
            select m;
    
    
    foreach (var item in x)
    {
        var grpY = int.Parse(item.Groups[0].Value) + 1; //???
        dict.Add("deqn" + grpY, item.Value);
    }
