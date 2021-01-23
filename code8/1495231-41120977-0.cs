    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
    {
        if (!column.CheckAccess())
        {
            // Houston, we've got a problem!
        }
        dataGrid.Columns.Add(column);
    }));
