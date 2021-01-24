LinkedIn is not rendering results list directly to html markup. He is rendering big json objects into `` element and then using JS to render that.
Your console app should be like this:
    static void Main(string[] args)
    {
        var html = @"https://www.linkedin.com/search/results/index/?keywords=firstname%3Ajohn%20AND%20lastname%3Adoe%20AND%20company%3Amicrosoft%20AND%20title%3Aceo&origin=GLOBAL_SEARCH_HEADER";
        HtmlWeb web = new HtmlWeb();
        web.PreRequest = new HtmlWeb.PreRequestHandler(OnPreRequest2);
        var htmlDoc = web.Load(html);
        var codeElement = htmlDoc.DocumentNode.SelectNodes("//code[starts-with(@id,'bpr-guid')][last()]");
        var json = WebUtility.HtmlDecode(codeElement.Last().InnerText);
        var obj = JsonConvert.DeserializeObject<Rootobject>(json);
        var profiles = obj.included.Where(i => i.firstName != null);
        foreach(var profile in profiles)
        {
            Console.WriteLine("Profile Name: " + profile.firstName + ";" + profile.lastName + ";" + profile.occupation + ";https://www.linkedin.com/in/" + profile.publicIdentifier); 
        }
        Console.ReadKey();
    }
    public static bool OnPreRequest2(HttpWebRequest request)
    {
        var cookies =   "li_at={YOURCOOKIEHERE};" +
                        "_lipt={YOURCOOKIEHERE}";
        request.Headers.Add(@"cookie:" + cookies);
        return true;
    }
    public class Rootobject
    {
        public Included[] included { get; set; }
    }
        
    public class Included
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string occupation { get; set; }
        public string objectUrn { get; set; }
        public string publicIdentifier { get; set; }
    }
At the end it will print 
    Profile Name: John;Doe;ceo at Microsoft;https://www.linkedin.com/in/john-doe-8102b868
    Profile Name: John;Doe;Ceo at Microsoft;https://www.linkedin.com/in/john-doe-63803769
    Profile Name: John;Doe;CEO at Microsoft;https://www.linkedin.com/in/john-doe-2151b69b
