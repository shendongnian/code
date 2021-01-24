    private static async Task<string> translate(string input, string languagePair)
    {
        string url = String.Format("https://translate.google.com/?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
        using (var hc = new HttpClient())
        {
            var result = await hc.GetStringAsync(url).ConfigureAwait(false);
            int start = result.IndexOf("result_box");
            string sub = result.Substring(start);
            sub = sub.Substring(0, sub.IndexOf("</span>"));
            start = sub.LastIndexOf(">");
            sub = sub.Substring(start + 1);
            return sub;
        }
    }
