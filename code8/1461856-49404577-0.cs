    string url_base=@"http://www.realtor.com/realestateagents/New-York_NY/photo-1/pg-";
    function GetPageContent(int page_no)
    {
       return new System.Net.WebClient().DownloadString(url_base+page_no);
    }
    var file_path=@"C:\Dump\Data.xml";
    
    var content=GetPageContent(1);
    
    System.IO.File.WriteAllText(file_path,content);
    
    
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.OptionFixNestedTags = true;
    doc.Load(file_path);
    
    var name = doc.DocumentNode.SelectNodes("//*[@id=\"agent_list_wrapper\"]//div//div//div/div//a");
    var phone = doc.DocumentNode.SelectNodes("//*[@id=\"agent_list_wrapper\"]//div//div//div//div");
    
    
    var names = name.Select(node => node.InnerText);
    var phones = phone.Select(node => node.InnerText);
    
    var result = names.Zip(phones, (n, p) => new { Name = n, Phone = p }).ToList();
    //Result has 58 items
