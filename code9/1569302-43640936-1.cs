    for (int i = 0; i < dataGrid.Columns.Count; i++)
    {
        var desiredColor = new SolidColorBrush(i % 2 == 0 ? Colors.White : Colors.LightBlue);
        dataGrid.Columns[i].CellStyle = new Style(typeof(DataGridCell));
        dataGrid.Columns[i].CellStyle.Setters.Add(new Setter(BackgroundProperty, desiredColor));
    }
