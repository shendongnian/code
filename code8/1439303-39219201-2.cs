    var str = Convert.ToString(ViewBag.Keyword);
    var possibleNames = str.split(' ');
    //to check if any match exists
    bool anyMatch = possibleNames.Any(n => n.Equals(result.Document.ContactName, StringComparison.InvariantCultureIgnoreCase));
    //get matched names
    var matchedNames = possibleNames.Where(n => n.Equals(result.Document.ContactName, StringComparison.InvariantCultureIgnoreCase));
    
    //do whatever you want with matchedNames now
    var array = matchedNames.ToArray();
    var list = matchedNames.ToList();
