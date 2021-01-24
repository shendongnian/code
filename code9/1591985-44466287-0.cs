	DateTime outDate;
    	for (int i = 0; i < GridView1.Rows.Count - 1; i++)
        {
    
            command.Parameters.AddWithValue("@Name", GridView1.Rows[i].Cells[0].Text);
            command.Parameters.AddWithValue("@Day_of_the_Week", DateTime.TryParse(GridView1.Rows[i].Cells[1].Text, out outDate) ? Convert.ToDateTime(GridView1.Rows[i].Cells[1].Text) : GridView1.Rows[i].Cells[1].Text);
            command.Parameters.AddWithValue("@Hours_Total",  GridView1.Rows[i].Cells[2].Text);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }
