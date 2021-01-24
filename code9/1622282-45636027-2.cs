    if (!dgvItems.Columns.Contains("clqty"))
    {
        DataGridViewColumn clqty = new DataGridViewColumn()
        {
            HeaderText = "Qunatity",
            CellTemplate = new DataGridViewTextBoxCell(),
            Name  = "clqty",
            Width = 10
        };
        dgvItems.Columns.Insert(3, clqty);
    }
