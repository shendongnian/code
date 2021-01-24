    var dict = new Dictionary<String, List<String>>();
    var a = File.ReadAllText(@"test.reg");
    var results = Regex.Matches(a, "(\\[[^\\]]+\\])([^\\[]+)\r\n\r\n", RegexOptions.Singleline);           
    foreach (Match item in results)
    {
    	dict.Add(
    		item.Groups[1].Value, 
    		item.Groups[2].Value.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList()
        );
    }
