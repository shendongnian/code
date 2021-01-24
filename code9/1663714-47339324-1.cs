    List<string> lstGolds = new List<string>();
    
    string xml ="<memberlist><member><name>Name</name><status>gold</status></member></memberlist>";
    XDocument doc = XDocument.Parse(xml);
    var goldStatus = doc.Descendants("member")
        .Where(d => d.Element("status").Value == "gold")
        .Select(d => d.Element("name").Value);
    lstGolds.AddRange(goldStatus);
