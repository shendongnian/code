    using System.Linq;
    ... 
    string queryEventID = string.Join(",", lstEvent  // Join query data:  
      .Items                                         //   Having lstEvent.Items
      .OfType<ListItem>()                            //   Obtain IEnumerable<ListItem>
      .Where(item => item.Selected)                  //   Selected only
      .Select(item => item.Value));                  //   Value (not item)
