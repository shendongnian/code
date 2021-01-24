    public List<CaseListEntry> GetCaseListEntries()
    {
        var elements = CaseListGrid.FindElements(By.TagName("td"));
        var listEntries = new List<CaseListEntry>();
    
        foreach (var element in elements)
        {
            var text = element.Text;
    
            if (!string.IsNullOrWhiteSpace(text))
                listEntries.Add(new CaseListEntry(text)); // I don't know what kind of class CaseListEntry is, so this is pseudo code
        }
    
        return listEntries;         
    }
