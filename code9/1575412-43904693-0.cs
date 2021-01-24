     public void GridView_Row_Merger(GridView gridView)
    {
        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow currentRow = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];
            string[] arra1 = currentRow.Cells[0].Text.Split(' ');
            string[] arra2 = previousRow.Cells[0].Text.Split(' ');
            currentRow.Cells[0].Text = arra1[0];
            previousRow.Cells[0].Text = arra2[0];
            if (currentRow.Cells[0].Text == previousRow.Cells[0].Text)
            {
                if (previousRow.Cells[0].RowSpan < 2)
                {
                    currentRow.Cells[0].RowSpan = 2;
                }
                else
                {
                    currentRow.Cells[0].RowSpan = previousRow.Cells[0].RowSpan + 1;
                }
                previousRow.Cells[0].Visible = false;
            }
        }
    }
