    public int djelatnikSelectedRowIndex { get; set; }
    
    private void djelatnikDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        djelatnikSelectedRowIndex = e.RowIndex;
    }
