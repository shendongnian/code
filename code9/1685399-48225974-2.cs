    List<string> queryEvents = lstEvent  
      .Items                             
      .OfType<ListItem>()                
      .Where(item => item.Selected)      
      .Select(item => item.Value)
      .ToList();
    string queryEventID = string.Join(",", queryEvents);
