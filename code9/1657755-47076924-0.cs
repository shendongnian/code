    string xmlContent = @"<Content><richtext><![CDATA[ <p> <strong>This is sample richtext content </strong> </p> ]]></richtext><htmlcontent> <![CDATA[<p> <strong>This is html content </strong> </p> ]]></htmlcontent><others> sample </others></Content>";
    var doc = XElement.Parse(xmlContent);
    var cdata = doc.DescendantNodes().OfType<XCData>().ToList();
    foreach(var cd in cdata)
    {
        cd.Parent.Add(cd.Value);
        cd.Remove();
    }
    Console.WriteLine(doc);
    string jsonText = JsonConvert.SerializeXNode(doc, Newtonsoft.Json.Formatting.Indented);
    Console.WriteLine(jsonText);
