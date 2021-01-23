    ListView.Items.AddRange(ListData.Where(i =>    
                string.IsNullOrEmpty(searchBox.Text) 
                || i.ID.StartsWith(searchBox.Text))
                .Select(c => CreateListViewItemFromElement(c)).ToArray());
    private ListViewItem CreateListViewItemFromElement(MyClass element)
    {
    // handle the element to create a "complete" ListViewItem with subitems
        ListViewItem item = new ListViewItem(c.ID);
        ....
        return item;
    }
