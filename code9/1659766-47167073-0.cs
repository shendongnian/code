    var list = new List<(int cId, string cName, string startDate)>
    {
        (1, "Math", "1/12"),
        (2, "Music", "1/12"),
        (3, "English", "1/12"),
        (4, "English", "11/4"),
        (5, "Swedish", "1/12"),
        (6, "Russia", "1/12")
    };
    var duplicates = new HashSet<string>(
                list.GroupBy(x => x.cName) //Group the items by name
                    .Where(g => g.Count() > 1) //Find groups with more than 1
                    .Select(g => g.Key)); //Just add the names to the HashSet, not the group
    foreach (var item in list)
    {
         var displayName = item.cName
         if(duplicates.Contains(displayName))
         {
             displayName += String.Format(" ({0})", item.startDate)
         }
         dplCourse.Items.Add(new ListItem(item.cId, displayName));
    }
