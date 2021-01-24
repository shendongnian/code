    string[] queryEvents = lstEvent  
      .Items                             
      .OfType<ListItem>()                
      .Where(item => item.Selected)      
      .Select(item => item.Value)
      .ToArray();
    string queryEventID = string.Join(",", queryEvents);
