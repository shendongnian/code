    Color[,] cellList;
    int cellWidth = 23;
    int cellHeight = 23;
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (cellList == null) InitCells(22, 22);
        for (int c = 0; c < cellList.GetLength(0); c++)
            for (int r = 0; r < cellList.GetLength(1); r++)
            {
                TableLayoutCellPaintEventArgs tep = new 
                    TableLayoutCellPaintEventArgs(e.Graphics,
                        Rectangle.Round(e.Graphics.ClipBounds),
                        new Rectangle(c*cellWidth, r*cellHeight, cellWidth, cellHeight), c, r);
                pictureBox1_CellPaint(e, tep);
            }
        // insert the gridline drawing here!
    }
    private void pictureBox1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        //if (mainVisualization.mainGrid != null)
        //    if (mainVisualization.mainGrid.cellList != null)
                using (var b = new SolidBrush(cellList[e.Column, e.Row]))
                    e.Graphics.FillRectangle(b, e.CellBounds);
    }
