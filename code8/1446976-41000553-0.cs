    private void gridEX1_CellChanged(object sender, ColumnActionEventArgs e)
    {
        if (e.Column.ColumnType == ColumnType.CheckBox)
        {
            gridEX1.UpdateData(); // Flush any pending changes
        }
    }
