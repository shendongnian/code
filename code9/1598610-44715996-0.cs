    string Charseparated = "test * -";
    var replacements = new Dictionary<string, string>()
    {
       {"*", string.Empty},
       {" ", "-"}
    };
    
    var reg = new Regex(String.Join("|", replacements.Keys.Select(k => Regex.Escape(k))));
    var reg_replace = reg.Replace(Charseparated, m => replacements[m.Value]);
