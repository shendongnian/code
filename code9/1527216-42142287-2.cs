    var ordered = animeSubNodesList.OrderBy(x => ConvertToTime(x.StartDate));
    
    foreach (var item in ordered) // Add childNode to parent
    {
            tvGroups.BeginUpdate();    
            tvGroups.Nodes[i].Nodes.Add(item);    
            tvGroups.EndUpdate();
    }
    
    
    private static DateTime ConvertToTime(string time)
    {
                return DateTime.Parse(time.Replace(" - ", "/"));
    }
