    //(This was done using HTML Agility Pack)
    string url = @"https://www.instagram.com/" + Console.ReadLine() + @"/?hl=en";
    HtmlWeb web = new HtmlWeb();
    HtmlDocument document = web.Load(url);
    var metas = document.DocumentNode.Descendants("meta");
    var followers = metas.FirstOrDefault(_ => _.HasProperty("name", "description"));
    if (followers == null) { Console.WriteLine("Sorry, Can't Find Profile :("); return; }
    var content = followers.Attributes["content"].Value.StopAt('-');
    Console.WriteLine(content);
