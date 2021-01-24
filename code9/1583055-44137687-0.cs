    // Split the script in its individual statements
    var splitArray = script.Split(';');
    // Get the statement you're interested in
    var line = splitArray.Where(x => x.Contains("result.thisiswhatiwant")).First();         
    // Remove all characters except numbers and commas, then split by comma       
    var values = Regex.Replace(line, "[^0-9,]", string.Empty).Split(',');
