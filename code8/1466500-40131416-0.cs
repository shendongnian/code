    private void AvoidDuplicates()
    {
        int i = GridView1.Rows.Count - 2; //GridView row count
        while (i >= 0) //Iterates through a while loop to get row index
        {
            GridViewRow curRow = GridView1.Rows[i]; //Gets the current row
            GridViewRow preRow = GridView1.Rows[i + 1]; //Gets the previous row
            int j = 0;
            while (j < curRow.Cells.Count) //Inner loop to get the row values
            {
                /****Condition to check if it has duplicate rows - Starts****/
                if (curRow.Cells[j].Text == preRow.Cells[j].Text) //Matches the row values
                {
                    if (preRow.Cells[j].RowSpan < 2)
                    {
                        curRow.Cells[j].RowSpan = 2;
                        preRow.Cells[j].Visible = false;
                    }
                    else
                    {
                        curRow.Cells[j].RowSpan = preRow.Cells[j].RowSpan + 1;
                        preRow.Cells[j].Visible = false;
                    }
                }
               /****Ccondition to check if it has duplicate rows - Ends****/
                j++;
            }
            i--;
        }
    } 
