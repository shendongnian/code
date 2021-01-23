    public static  bool PartHasTrackedRevisions(OpenXmlPart part)
    {
         bool isFound = false;
         var typesFound = part.RootElement.Descendants()
                                          .Where(e => trackedRevisionsElements.Contains(e.GetType())).ToList();
        foreach(System.Type foundType in typesFound)
        {
            MessageBox.Show(foundType .ToString());
            isFound  = true;
        }
        return isFound; 
    }
