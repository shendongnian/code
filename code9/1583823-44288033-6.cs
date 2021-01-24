    SqlDataAdapter da = new SqlDataAdapter(cmdstr ,con);
        da.SelectCommand.CommandType = CommandType.Text;
        da.SelectCommand.Parameters.AddWithValue("@ID", lblEditID.Text);
        da.SelectCommand.Parameters.AddWithValue("@Name", txtEditName.Text);
        da.SelectCommand.Parameters.AddWithValue("@Salary", txtEditSalary.Text);
        da.SelectCommand.Parameters.AddWithValue("@Designation", txtEditDesignation.Text);
        da.SelectCommand.Parameters.AddWithValue("@Location", txtEditLocation.Text);   
    
    DataSet dsResult = new DataSet();
    da.Fill(dsResult);
    con.Close();
    GridView2.DataSource = dsResult;
    GridView.DataBind();
