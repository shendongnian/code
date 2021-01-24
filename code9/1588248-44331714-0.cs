    private void InspectionDataGridViewCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ContextMenu m = new ContextMenu();
    
            int currentRow = e.RowIndex;
                if (this.currentInspection != null) // the row that is being right-clicked might not be the row that is selected.
                {
                    var MI = new MenuItem(string.Format("Mark inspection point {0} as complete.", this.currentInspection.InspectionNumber), this.markInspectionPointComplete)
                    {
                        Tag = sender
                    };
                    m.MenuItems.Add(MI);
                }
            m.Show(this.InspectionDataGridView, new Point(e.X,e.Y));
        }
    }
    
    private void markInspectionPointComplete(object sender, EventArgs e)
    {
        var MI = (MenuItem)sender;
        var Obj = MI.Tag;
    
        // Do whatever you want with your Obj
        
        MessageBox.Show("the right-click menu works.");
    }
