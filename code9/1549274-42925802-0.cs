    sqlCmd.Connection = con;
    sqlCmd.CommandType = CommandType.Text;
    sqlCmd.CommandText = "SELECT pid FROM report2";
    System.Data.SqlClient.SqlDataAdapter sqlDataAdap = new
       System.Data.SqlClient.SqlDataAdapter(sqlCmd);                                                                                                                                                                                                               
    DataTable dtRecord = new DataTable();
    sqlDataAdap.Fill(dtRecord);
    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; //this statement added
    comboBox1.DataSource = dtRecord;
    comboBox1.ValueMember = "pid";
    con.Close();
