    private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
    {
         DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
   
        if (view.FocusedColumn.FieldName == "<name of check field>" && view.GetRowCellValue(view.FocusedRowHandle, "<other field>").ToString()!="editable value"))
               e.Cancel = true;
    }
