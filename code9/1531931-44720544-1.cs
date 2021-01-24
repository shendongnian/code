    private MyType SelectedItem
    {
        get {return ((ObjectView<MyType>)this.MyBindingSource.Current)?.Object; }
    }
    private void DisplayItems (IEnumerable<MyType> itemsToDisplay)
    {
        this.MyItems.DataSource = itemsToDisplay.ToList();
        this.MyItems.Refresh(); // this will update the DataGridView
    }
    private IEnumerable<MyType> DisplayedItems
    {
        get {return this.MyItems; }
        // BindingListview<T> implements IEnumerable<T>
    }
