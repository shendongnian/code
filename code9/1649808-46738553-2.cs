    ...
    headers.Add("Tot Entra");
    headers.Add("Tot Cargas");
    for (int j=0; j < headers.Count; j++)
    {
        DataGridTextColumn textColumn = new DataGridTextColumn();
        textColumn.Header = headers[j];
        textColumn.Binding = new Binding("TotBal");
        AcumProp.Columns.Add(textColumn);
    }
