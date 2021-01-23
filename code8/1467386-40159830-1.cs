    public ActionResult Search(string search_string)
    {
    	string regString = Regex.Replace(search_string.Trim(), @"[^A-Za-z0-9\s]", @"\$0"); //escape possible regex characters
		regString = Regex.Replace(regString, @"\s+", @"|"); //replace whitespace with "or" search operator
		regString = Regex.Replace(regString, @"[^\|]+", @"\b$0\b"); //optionally make words match whole words (can comment this out to allow partials)
    
    	Regex regex = new Regex(regString, RegexOptions.IgnoreCase); //create regex and ignore character case
    
    	return view(db.AttributesTable.Where(x => regex.IsMatch(x.Description)).ToList());
    }
