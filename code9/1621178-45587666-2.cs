    public Dictionary<string, string> ListEntries(string sectionName)
    {
        IniFile INI = new IniFile(@"C:\Races.ini");
    
        string[] Entry = INI.GetEntryKeyNames(sectionName);
        var entries = Entry .Where(x => !string.IsNullOrEmpty(x))
                            .ToDictionary( m => m,
                                           m => INI.GetEntryKeyValue(sectionName, m) );
    
        return entries;
    }
