     public void HighlightDuplicate(GridView gridview)
    {
        for(int currentRow = 0; currentRow < gridview.Rows.Count - 1; currentRow++)
        {
            GridViewRow rowToCompare = gridview.Rows[currentRow];
            for (int otherRow = currentRow + 1; otherRow < gridview.Rows.Count; otherRow++)
            {
                GridViewRow row = gridview.Rows[otherRow];
                bool duplicateRow = true;
                //example: check Duplicate on Coloumn vendor(cell#0) and product(cell#1)
                if ((rowToCompare.Cells[0].Text) != (row.Cells[0].Text) && (rowToCompare.Cells[1].Text) != (row.Cells[1].Text))
                {
                    duplicateRow = false;
                }
                else if (duplicateRow)
                {
                    rowToCompare.Cells[1].Text = Convert.ToInt32(row.Cells[1].Text) + Convert.ToInt32(rowToCompare.Cells[1].Text);
    row.Visible=false;
                }
            }
        }
    }
    
