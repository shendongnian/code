    public NavDirectoryViewModel GetAllUserNavItems(string userId)
    {
        NavDirectoryViewModel model = new NavDirectoryViewModel();
        model.Items = GetNavItems(0, userId).OrderBy(x => x.SortOrder);
        return model;
    }
    private static IEnumerable<NavViewModel> GetNavItems(int parentId, string userId)
    {
        List<NavViewModel> items = new List<NavViewModel>();
        var children = GetAllNavItems(parentId);
        foreach (var child in children)
        {
            if (child.IsUserAllowed(userId))
            {
                var navItem = new NavViewModel() { Name = child.Name, Href = child.Href, Image = child.Image, SortOrder = child.SortOrder };
                navItem.SubItems = GetNavItems(child.Id, userId);
                items.Add(navItem);
            }
        }
        return items;
    }
