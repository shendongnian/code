          private void button1_Click(object sender, EventArgs e)
                 {  con = new SqlConnection(cs.DBConn);
         
                     foreach (DataGridViewRow dgRow in dgw.Rows)
                    {
                         string id = dgRow.Cells[0].Value.ToString(); 
                         string date = dgRow.Cells[1].Value.ToString();
                         DateTime  test;
                         string cb = "update date set date='" + DateTime.TryParseExact(date, "dd/MM/yyyy",
        CultureInfo.InvariantCulture, DateTimeStyles.None, out test) +  "' where id='" + id + "'";
       
                       con.Open();
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                       cmd.ExecuteReader();
                      con.Close();
         
                 } 
    }
