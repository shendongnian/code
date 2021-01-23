    static void Main(string[] args)
    {
        var html = @"<div class=""vcard - names - container py - 3 js - sticky js - user - profile - sticky - fields "" style=""position: static; "">
               < h1 class=""vcard-names"">
                <span class=""vcard-fullname d-block"" itemprop=""name"">Name 001</span>
                <span class=""vcard-username d-block"" itemprop=""additionalName"">Name 002</span>
              </h1>
            </div>";
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        var names = doc.DocumentNode.SelectNodes("//span").Select(x => x.InnerText);
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
        Console.ReadLine();
    }
