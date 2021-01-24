    for(int row = 0; row < 10; row++)
    {
        TableRow newRow = new TableRow();
        MulitiplicationTable.Rows.Add(newRow);
    
        for (int column = 0; column < 10; column++)
        {
            TableCell newCell = new TableCell();
            newRow.Cells.Add(newCell);
            //Empty cell for our first cell...                    
            if ((row + column) == 0)
            {
                newCell.Text = "&nbsp;";
            }
            //Our Column and row headers are also
            //Special Cases
            else if(row == 0)
            {
                newCell.Text = column.ToString();
                newCell.CssClass = "columnHead";
            }
            else if(column == 0)
            {
                newCell.Text = row.ToString();
                newCell.CssClass = "rowHead";
            }
            //Now do the math
            else
            {
                newCell.Text = (row * column).ToString();
            }
        }
    }
