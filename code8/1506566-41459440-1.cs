    private void Grid_MasterRowExpanded(System.Object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
    {
    	GridView view = sender;
    	GridView detail = view.GetDetailView(e.RowHandle, e.RelationIndex);
    
    	if (e.RowHandle == 0 | e.RowHandle == 1) {
    		if (detail.Name == "BOM") {
    			detail.Columns["Column Name"].Visible = false;
    		}
    	}
    }
