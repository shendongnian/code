    SqlDataAdapter myadp3 = new SqlDataAdapter("select * FROM Login WHERE username='" + DropUser.SelectedItem.Text+ "' and pass='" + TextBox1.Text+"'", conn);
    DataSet DSS = new DataSet();
    adp.Fill(DSS);
    if(DSS.Tables.Count>0){
        if(DSS.Tables[0].Rows.Count>0){
            return true; // login success
        }
    }
