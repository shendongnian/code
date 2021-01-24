    List<string> PlacesList= new List<string>();
    List<string> PositionsList= new List<string>();
    public void btnReadini_Click(object sender, EventArgs e)
    {
        PlacesList = ListEntries("Places");
        PositionsList = ListEntries("Positions");
    }
    
    public List<string> ListEntries(string sectionName)
    {
        IniFile INI = new IniFile(@"C:\Races.ini");
        List<string> entries = null;
    
        string[] Entry = INI.GetEntryKeyNames(sectionName);
        if (Entry != null)
        {
            entries = new List<string>();
    
            foreach (string EntName in Entry)
            {
                entries.Add(EntName + "=" + INI.GetEntryKeyValue(sectionName, EntName));
            }
        }
    
        return entries;
    }
