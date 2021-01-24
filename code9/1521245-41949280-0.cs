    private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName.Contains('.') && e.Column is DataGridBoundColumn)
        {
            DataGridBoundColumn dataGridBoundColumn = e.Column as DataGridBoundColumn;
            dataGridBoundColumn.Binding = new Binding("[" + e.PropertyName + "]");
            dataGridBoundColumn.SortMemberPath = e.PropertyName;
        }
    }
