    public IEnumerable<string> EmbeddedFonts
    {
        get
        {
            return doc.ObjectSoup.Catalog.GetFonts()
              .Select(x => x.BaseFont).Where(x => 
                 !x.StartsWith("Helvetica") && 
                 !x.StartsWith("Times") && 
                 !x.StartsWith("Zapf")).Distinct().OrderBy(x => x);
        }
    }
