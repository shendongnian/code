    Dictionary<string,string> tableData = new Dictionary<string, string>();
    var trNodes = eachNode.FindElements(By.TagName("tr"));
    
    foreach (var trNode in trNodes)
    {
        var name = trNode.FindElement(By.CssSelector(".name")).Text.Trim();
        var value = trNode.FindElement(By.CssSelector(".value")).Text.Trim();
    
        tableData.Add(name,value);
    }
    
    var location = tableData["location"];
