    private async Task<int> FillAndGetRowCount( ... ) // add parameters if needed
    {
        this.singleCenTableAdapter.Fill(this.singleCenData.SingleCenTable, ((System.DateTime)(System.Convert.ChangeType(txtBookFrom.Text, typeof(System.DateTime)))), ((System.DateTime)(System.Convert.ChangeType(txtBookTo.Text, typeof(System.DateTime)))));
        return singleCenTableDataGridView.RowCount;
    }
