    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Base;
    
    private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e) {
        if(e.Control && !e.Alt && !e.Shift && (e.KeyCode == Keys.Home || e.KeyCode == Keys.End)) {
            ColumnView view = ((GridControl)sender).FocusedView as ColumnView;
            if(view != null)
                view.ClearSelection();
        }
    }
