    DateTime outDate;
    IFormatProvider culture = new CultureInfo("en-US", true)
        for (int i = 0; i < GridView1.Rows.Count - 1; i++)
        {
    
            command.Parameters.AddWithValue("@Name", GridView1.Rows[i].Cells[0].Text);
            command.Parameters.AddWithValue("@Day_of_the_Week",  Datetime.ParseExact(GridView1.Rows[i].Cells[1].Text, "yyyy-MM-dd", culture);
            command.Parameters.AddWithValue("@Hours_Total",  GridView1.Rows[i].Cells[2].Text);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }
