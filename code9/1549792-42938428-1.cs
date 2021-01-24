    public ObservableCollection<ListViewItem> RecursiveActionBuilder(List<IMetaData> pList)
    {
        if (pList == null)
            return null;
    
        var items = pList
            .Expand(e => e.Children)
            .Select(e => e.Children == null && e.Tag == Enums.TestType.Action ? e as ActionObject : null)
            .Where(e => e != null)
            .Select(e => new ListViewItem()
            {
                Values = new ListViewValue[]
                {
                    new ListViewValue() { Value = e.Command },
                    new ListViewValue() { Value = e.Target },
                    new ListViewValue() { Value = e.Value },
                    new ListViewValue() { Value = e.Comment }
                }
            });
    
        return new ObservableCollection<ListViewItem>(items);
    }           
