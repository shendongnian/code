    SearchData.Text
    public DataTable Search_Data(){
       adap = new SqlDataAdapter("select * from MyTable " +
                                      "where MyID = '" + 
                                       SearchData.Text + 
                                       "'", con);
       dt = new DataTable();
       adap.Fill(dt);
       return dt;
    }
