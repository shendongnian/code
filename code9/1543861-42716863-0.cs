    string content = "The Password for the website is monafsfasdey";
    Regex pattern = new Regex(@"\bis\b\s(.*?)$");
    var match = pattern.Match(content);
    if (match.Success)
    {
        string replace = new string( 'X', match.Groups[1].Value.Length);
        content = pattern.Replace(content, replace);
    }
