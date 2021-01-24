    foreach (var item in itemsSource)
    {
        var serialrow = item as System.Data.DataRowView;
        if (serialrow != null)
        {
            var name = serialrow["ColumnName"].ToString();
        }
    }
