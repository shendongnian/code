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
                //You handled a couble click on column
                //Do what you need
            }
        }
    }
