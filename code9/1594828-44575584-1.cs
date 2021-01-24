    string templateFile = @"C:\Users\template.json";
    string outputFile = @"C:\Users\output.json";
    //rss
    JObject template = JObject.Parse(File.ReadAllText(templateFile));
    
    foreach (var record in template)
    {
        string name = record.Key;
        JToken value = record.Value;
        foreach(var obj in value)
        {
            //fetch two values from each json object, 
            //based on these , fetch a flag and then add it to the json object
            var ep = obj["attributes"];
            ep = ep["ePCode"].Value<int?>();
            var cost = obj["ccCode"].ToString();
            bool isCostValuable = isCostValuable((int)ep, cost);
    
            ep.Add("newFlag", isCostValuable);
        }
    }
    File.WriteAllText(outputFile, templateFile.ToString());
