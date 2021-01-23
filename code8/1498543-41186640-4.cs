    private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        DateTime parsed;
        if (!DateTime.TryParse(e.FormattedValue.ToString(), out parsed))
        {
            this.dataGridView1.CancelEdit();
        }
    }
