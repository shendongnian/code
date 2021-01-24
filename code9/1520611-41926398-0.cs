    private bool Check(string result, string type) {
        if (result.Equals("") && type == "")
            {
                JObject jobj = JObject.Parse(Helper.callerClass(@""));
                var titleTokens = jobj.SelectTokens("...title");
                var values = titleTokens.Select(x => (x as JProperty).Value);
                if (titleTokens.Contains(s))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
    }
