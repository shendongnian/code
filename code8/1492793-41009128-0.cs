    private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
            {
                GridView view = sender as GridView;
                try
                {
                    if ((e.Column.FieldName == "ColumnName"))
                    {
                        object value1 = view.GetRowCellValue(e.RowHandle1, e.Column);
                        object value2 = view.GetRowCellValue(e.RowHandle2, e.Column);
    
                        e.Merge = (value1 == value2)||(value1 == null || value2 == null);
                        e.Handled = true;
                        return;
                    }
                }
                catch (Exception ex)
                {
                }
            }
