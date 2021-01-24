    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int index = e.Row.RowIndex;
                GridViewRow prevRow = null;
                GridViewRow currentRow = e.Row;
                if (index > 0)
                {
                    int PrevIndex = index - 1;
                    prevRow = (GridViewRow)gvData.Rows[PrevIndex];
                }
                if (prevRow != null)
                {
                    if (prevRow.Cells[0].Text == currentRow.Cells[0].Text && (prevRow.Cells[0].Text != "" && currentRow.Cells[0].Text != ""))
                    {
                        prevRow.Cells[0].RowSpan += 2;
                        currentRow.Cells.RemoveAt(0);
                    }
                    else
                    {
                        prevRow.Cells[0].RowSpan += 0;
                    }
                }
            }
        }
