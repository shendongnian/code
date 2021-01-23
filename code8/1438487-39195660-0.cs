     using(var con = new SqlConnection(...))
        {
        var cmd = new SqlCommand("select Dmokalafiat, Dihteyat  from Armyservices where Ename = @Ename ", con);
        con.Open();
        cmd.Parameters.AddWithValue("@Ename ", txtsearch.Text);
        var da = new SqlDataAdapter(cmd);
        var dt = new DataTable();
        da.Fill(dt);
          if (dt.Rows.Count > 0)
          {
            Textbox1.Text = dt.Rows[0]["Dmokalafiat"].ToString();
            Textbox2.Text = dt.Rows[0]["Dihteyat"].ToString();
          }
        }
