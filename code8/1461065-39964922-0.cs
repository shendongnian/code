    private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
    {
        if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            return;
    
        DXMenuItem restoreItem = new DXMenuItem() { Caption = "Restore Layout" };
        restoreItem.Click += restoreItem_Click;
    
        e.Menu.Items.Add(restoreItem);
    }
    
    private void restoreItem_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Restoring layout...");
    }
