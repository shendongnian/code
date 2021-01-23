    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    sda.Fill(ds);
    Control abc = this.FindControl("divv");
    Label lbl = new Label();
    abc.Controls.Add(lbl);
    lbl.Text = ds.Tables[0].Rows[0]["mv_title"].ToString();
    con.close();
