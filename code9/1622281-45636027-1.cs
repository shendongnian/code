    DataGridViewColumn clqty = new DataGridViewColumn()
    {
        HeaderText = "Qunatity",
        CellTemplate = new DataGridViewTextBoxCell(),
        Name  = "clqty",
        Width = 10
    };
    if (!dgvItems.Columns.Contains("clqty"))
         dgvItems.Columns.Insert(3, clqty);
