    private void InspectionDataGridViewCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ContextMenu m = new ContextMenu();
            int currentRow = e.RowIndex;
                if (this.currentInspection != null) // the row that is being right-clicked might not be the row that is selected.
                {
                    var MI = new MenuItem(string.Format("Mark inspection point {0} as complete.", this.currentInspection.InspectionNumber));
                    MI.Click += (s, x) =>
                    {
                        // Use 'e' or 'sender' here
                    }
                    m.MenuItems.Add(MI);
                }
            m.Show(this.InspectionDataGridView, new Point(e.X,e.Y));
        }
    }
