    private void GetSelectedRecordIds()
    {
        IList selectedRows = (IList)licenseGrid.SelectedItems;
        var stronglyTypedList = selectedRows.Cast<MyType>();
        foreach (MyType m in stronglyTypedList)
        {
            int id = m.ID;
            // do something with ID
        }
    }
