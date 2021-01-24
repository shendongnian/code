    private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        var handler = ItemHasBeenSelected;
        if (e.RowIndex >= 0 && e.RowIndex < DataGridView.RowCount)
        {
            // 6 == id column
            int choice = (int)DataGridView[6, First ? 0 : e.RowIndex].Value;
            if (handler != null) handler(this, new SelectedItemEventArgs { SelectedChoice = choice });
            this.DialogResult = DialogResult.OK;
        }
    } 
