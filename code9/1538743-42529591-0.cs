    private void filter(int selectedID) {
        DataTable dtFilter = new DataTable();
        //speichere GridView zum Filtern
        dtFilter = (DataTable)this.grdMDT.DataSource;
        try {
            dtFilter = dtFilter.Select("ID = " + selectedID).CopyToDataTable();
            this.DGV.DataSource = dtFilter;
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }
    }
