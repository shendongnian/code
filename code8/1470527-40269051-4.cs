    private void dataGridView1_DoubleClick(object sender, EventArgs e)
    {
        var g = sender as DataGridView;
        if (g != null)
        {
            var p = g.PointToClient(MousePosition);
            var hti = g.HitTest(p.X, p.Y);
            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
            {
                var columnIndex = hti.ColumnIndex;
                //You handled a double click on column header
                //Do what you need
            }
            else if (hti.Type == DataGridViewHitTestType.RowHeader)
            {
                var rowIndex = hti.RowIndex;
                //You handled a double click on row header
                //Do what you need
            }
        }
    }
