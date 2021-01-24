    var links = Sitecore.Globals.LinkDatabase.GetItemReferrers(item, true);
    string oldIdWithoutBraces = item.ID.ToString().Replace("{", "").Replace("}", "");
    string newIdWithoutBraces = newItem.ID.ToString().Replace("{", "").Replace("}", "");
    string oldIdForHyperlinks = oldIdWithoutBraces.ToLower().Replace("-", "");
    string newIdForHyperlinks = newIdWithoutBraces.ToLower().Replace("-", "");
