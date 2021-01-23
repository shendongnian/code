    XDocument doc = XDocument.Parse(File.ReadAllText("XMLFile1.xml"));
    var allParties = doc.Descendants("commercial").Elements("party");
    
    // invalid primary parties with more than 1 listing agent
    var invalidPrimaries = allParties.Where(p => p.Element("role_detail")?.Value.ToUpper() == "PRIMARY" && 
                                                 p.Element("listingagents")?.Elements("listingagent").Count() > 1);
    
    var validParties = allParties.Except(invalidPrimaries);
    var validCommericals = validParties.Select(p => p.Parent).Distinct().ToList();
