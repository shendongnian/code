        if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell cell = e.Row.Cells[1];
                int quantity = int.Parse(cell.Text);
                if (quantity <= 0)
                {
                    cell.ForeColor = Color.Red;
                } 
    
                TableCell cell2 = e.Row.Cells[2];
                int quantity = int.Parse(cell.Text);
                if (quantity <= 0)
                {
                    cell2.ForeColor = Color.Red;
                } 
            }
