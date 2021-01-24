    var filename = Path.Combine(Android.OS.Environment.ExternalStorageDirectory, "pullList" + pullMonth + ".csv");
    
    StringBuilder s = new StringBuilder();
    
    // build the data in memory
    foreach (var listing in allTables)
    {
        s = s.AppendLine(listing.ComicTitle);
    }
    
    // write the data all at once
    File.WriteAllText(path,s);
