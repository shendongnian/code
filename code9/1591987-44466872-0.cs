    DateTime minValue = new DateTime(1900,1,1); // Arbitrary for missing values 
    command.Parameters.Add("@Name", SqlDbType.NVarChar);
    command.Parameters.Add("@Day_of_the_Week", SqlDbType.DateTime);
    command.Parameters.AddWithValue("@Hours_Total", SqlDbType.NVarChar);
    for (int i = 0; i < GridView1.Rows.Count - 1; i++)
    {
        DateTime day;
        if(!DateTime.TryParse(GridView1.Rows[i].Cells[1].Text, out day)
           day = minValue;
        command.Parameters["@Name"].Value = GridView1.Rows[i].Cells[0].Text;
        command.Parameters["@Day_of_the_Week"].Value = day;
        command.Parameters["@Hours_Total"].Value = GridView1.Rows[i].Cells[2].Text;
        command.ExecuteNonQuery();
    }
