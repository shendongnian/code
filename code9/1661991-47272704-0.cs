    using System.Linq;
    
    Then
    
    List<SPListItem> allItems = new List<SPListItem>();
    allItems.AddRange(list.GetItems(spQuery).Cast<SPListItem>().ToList());
    allItems.AddRange(list2.GetItems(spQuery).Cast<SPListItem>().ToList());
    
    //Do something to the "allItems"
