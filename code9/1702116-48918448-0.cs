    private bool RemoveBoundItem(ListBox control, object item)
    {
        // Try to get the data source as an IList.
        var dataSource = control.DataSource as IList;
        if (dataSource == null)
        {
            // Try to get the data source as an IListSource.
            var listSource = control.DataSource as IListSource;
            if (listSource == null)
            {
                // The control is not bound.
                return false;
            }
            dataSource = listSource.GetList();
        }
        try
        {
            dataSource.Remove(item);
        }
        catch (NotSupportedException)
        {
            // The data source does not allow item removal.
            return false;
        }
        // The item was removed.
        return true;
    }
