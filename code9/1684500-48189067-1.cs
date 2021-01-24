    foreach(GridViewRow row in YourGridViewID.Rows)
    {
        for(int i = 0; i < YourGridViewID.Columns.Count; i++)
        {
                   TableCell cell = row.Cells[i];
                    int quantity = int.Parse(cell.Text);
                    if (quantity <= 0)
                    {
                        cell.ForeColor = Color.Red;
                    } 
        }
    }
            
