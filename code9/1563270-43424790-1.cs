    DateTime init  = monthCalendar1.SelectionEnd;
    DateTime finish = init.AddDays(1);
    con.Open();
    SqlCommand cmd = con.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = @"Select * from selectItems 
                       where [last_stock_date] >= @init 
                         AND [last_stock_date] < @finish";
    cmd.Parameters.Add("@init", SqlDbType.DateTime).Value = init;
    cmd.Parameters.Add("@finish", SqlDbType.DateTime).Value = finish;
    DataTable dt = new DataTable();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
    dataGridView1.DataSource = dt;
    con.Close();
