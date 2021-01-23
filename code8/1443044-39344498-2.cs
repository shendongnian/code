    private MenuItem CreateAscendingSortMenuItem(string prop)
    {
        var result = new MenuItem() { Header = "Asc" };
        result.Click += (s, e) =>
        {
            var toRemove = lv.Items.SortDescriptions.Where(x => x.PropertyName == prop).ToList();
            foreach (var item in toRemove)
            {
                lv.Items.SortDescriptions.Remove(item);
            }
            lv.Items.SortDescriptions.Insert(0, new SortDescription(prop, ListSortDirection.Ascending));
        };
        return result;
    }
    private MenuItem CreateDescendingSortMenuItem(string prop)
    {
        var result = new MenuItem() { Header = "Desc" };
        result.Click += (s, e) =>
        {
            var toRemove = lv.Items.SortDescriptions.Where(x => x.PropertyName == prop).ToList();
            foreach (var item in toRemove)
            {
                lv.Items.SortDescriptions.Remove(item);
            }
            lv.Items.SortDescriptions.Insert(0, new SortDescription(prop, ListSortDirection.Descending));
        };
        return result;
    }
