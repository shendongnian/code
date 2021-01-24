    private void UpdateTotalTime(DevExpress.XtraGrid.Views.Base.ColumnView View)
    {
         for (int i = 0; i < gridView.SelectedRowsCount; i++)
         {
              int rowHandle = gridView.GetSelectedRows()[i];
              GridView detail = (GridView)gridView.GetDetailView(rowHandle,0);
         } 
    }
