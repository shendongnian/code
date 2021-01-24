    var raw = "yourxmlhere";
    var xdoc = XDocument.Parse(raw);
    XNamespace ns = "http://www.opengis.net/kml/2.2";
    Dictionary<string,bool> dictionary = new Dictionary<string,bool>();
    var descendants = xdoc.Root.Descendants(ns + "Placemark").ToList();
		
	foreach(var node in descendants){
		string key = string.Join("", node.Elements().Select(el => el.Value));
		if(dictionary.ContainsKey(key))
			node.Remove();
		else
			dictionary.Add(key, true);
	}
    //at this point your xdoc only contains unique Placemark nodes
