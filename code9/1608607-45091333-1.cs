    private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        DataGridViewImageCell iCell = 
                         dataGridView1[e.ColumnIndex, e.RowIndex] as DataGridViewImageCell;
        Text = "MISS";
        if (iCell != null)
        {
            Image img = iCell.FormattedValue as Image;
            Rectangle irect = new Rectangle(0, 0, img.Width, img.Height);
            Point relLoc = e.Location;
            if (irect.Contains(relLoc)) Text = "HIT";
        }
    }
