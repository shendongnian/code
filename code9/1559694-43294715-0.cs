    private void LoadGridView()
    {
        invTable = new DataTable();
        // Code to populate invTable with the data..
        InGridView.DataSouce = invTable;
        inGridView.DataBind();
    }
