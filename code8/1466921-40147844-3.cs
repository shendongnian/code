    public void MergeCells(Graphics graph)
    {
        string subjForDict = renamingSubjects(takenSubj[0]);
        int cellIndex = 
            dataGrid.GetCellDisplayRectangle(dataGrid.Columns[selectedSubject0].Index;
        Rectangle CellRect1 = dataGrid.GetCellDisplayRectangle(cellIndex, rowNum, true);
        Rectangle CellRect2 = dataGrid.GetCellDisplayRectangle(cellIndex, 
                                                               rowNum + rowLength - 1, true);
        int rectHeight = 0;
        string MergedRows = String.Empty;
        for (int x = rowNum + 2; x <= rowNum + (rowLength + 1); x++)
        {
            rectHeight += dataGrid.GetCellDisplayRectangle(cellIndex, x, true).Height;
        }
        Rectangle newCell = new Rectangle(CellRect1.X, CellRect1.Y,
                                          CellRect1.Width, rectHeight);
        using (Font font=new Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Pixel))
        using (SolidBrush brush = new SolidBrush(Color.Black))
        {      
            int px = newCell.X + newCell.Width / 11;
            graph.DrawString("SUBJECT:", font, brush, px, newCell.Y + newCell.Height / 10);
            graph.DrawString("ENGLISH", font, brush, px, newCell.Y + newCell.Height / 2);
        }
    }
