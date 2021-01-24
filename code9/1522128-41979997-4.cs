    var urls = new Dictionary<string, string>();
    urls.Add("/old", "/new");
    
    var lines = new List<string>();
    
    lines.Add("<rewriteMaps>");
    lines.Add("<rewriteMap name=\"Redirects\">");
    
    foreach (var url in urls)
    {
    	lines.Add(string.Format("<add key=\"{0}\" value=\"{1}\" />", url.Key, url.Value));
    }
    
    lines.Add("</rewriteMap>");
    lines.Add("</rewriteMaps>");
    
    System.IO.File.WriteAllLines(@"rewriteMaps.config", lines);
