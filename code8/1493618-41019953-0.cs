    public class GetAUrl : WebTestRequestPlugin
    {
        public string ContextParameter { get; set; }
        public override void PostRequest(object sender, PostRequestEventArgs e)
        {
            string body = e.Response.BodyString;
            // Looking for requests in a specific class.
            string pattern = "\\bclass=\"nav__link-[23]\" +href=\"(/[^\"]*)\"";
            // The URL is in this capture:                        ^^^^^^^^^
            MatchCollection matches = Regex.Matches(body, pattern);
            int randomIndex = GetARandomNumber(matches.Count);
            //  Above will get a value 0 <= randomIndex < matches.Count
            e.WebTest.Context[ContextParameter] = matches[randomIndex].Groups[1].Value;
        }
    }
