    public ObservableCollection<TreeNodeItem> TreeNodeBuilder(List<IMetaData> pList)
        {
            if (pList == null)
                return null;
            var items = pList
                .Select(e => new TreeNodeItem()
                {
                    Header = e.Name,
                    Tag = e.Tag.ToString(),
                    Focusable = true,
                    Children = TreeNodeBuilder(e.Children)
                });
            return new ObservableCollection<TreeNodeItem>(items);
        }
