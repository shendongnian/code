    if (column.CheckAccess())
    {
        if (dataGrid.CheckAccess())
        {
            // Code here. You may need to check `Columns` as well but like I said I am not sure about this one.
        }
        else
        {
            dataGrid.Dispatcher.BeginInvoke(/* code here */);
        }
    }
    else
    {
        column.Dispatcher.BeginInvoke(/* code here */);
    }
