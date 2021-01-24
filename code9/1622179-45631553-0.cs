    int totalCount = 0;
    for (int i = 0; i < dataGridView1.RowCount; i++)
    {
        if (dg.Rows[i].Cells[1].Value.ToString().Trim() == "4 - Urgent") 
       //Trim() for removing whitespaces
        {
             totalCount += 1;
             MessageBox.Show(i); // this will give you the row index
        }
    }
    MessageBox.Show(totalCount.ToString()); //Total no of rows containing  "4 - Urgent"
