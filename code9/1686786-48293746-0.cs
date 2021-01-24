    private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)  {
        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "Check", DBNull.Value);
    }
    private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)    {
        if (e.Column.FieldName == "Check" && e.CellValue == DBNull.Value)
            e.RepositoryItem = repositoryItemTextEdit1;
    }
