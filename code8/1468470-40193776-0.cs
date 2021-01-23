    //using HtmlAgilityPack
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    //Considering first script tag (you need to check your decentands)
    var script = doc.DocumentNode.Descendants()
                                 .Where(n => n.Name == "script")
                                 .First().InnerText; 
    
    // Return the data of the spect and stringify it into a proper JSON object
    var engine = new Jurassic.ScriptEngine();
    var result = engine.Evaluate("(function() { " + script + " return spects; })()");
    var json = JSONObject.Stringify(engine, result);
    
    Console.WriteLine(json);
    Console.ReadKey();
