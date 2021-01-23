    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.OptionFixNestedTags = true;
    doc.Load("data.xml");
    var name = doc.DocumentNode.SelectNodes("//*[@id=\"agent_list_wrapper\"]//div//div//div/div//a");
    var phone = doc.DocumentNode.SelectNodes("//*[@id=\"agent_list_wrapper\"]//div//div//div//div");
   
    var names = name.Select(node => node.InnerText);
    var phones = phone.Select(node => node.InnerText);
    var result = names.Zip(phones, (n, p) => new { Name = n, Phone = p }).ToList();
    //Result has 58 items
