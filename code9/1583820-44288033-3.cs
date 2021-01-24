    SqlCommand cmd = new SqlCommand(cmdstr ,con);
        cmd.Parameters.AddWithValue("@ID", lblEditID.Text);
        cmd.Parameters.AddWithValue("@Name", txtEditName.Text);
        cmd.Parameters.AddWithValue("@Salary", txtEditSalary.Text);
        cmd.Parameters.AddWithValue("@Designation", txtEditDesignation.Text);
        cmd.Parameters.AddWithValue("@Location", txtEditLocation.Text);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.SelectCommand.CommandType = CommandType.Text;
    foreach (SqlParameter parameter in _parameters)
    {
     da.SelectCommand.Parameters.Add(parameter);
    }
    DataSet dsResult = new dsResult();
    da.Fill(dsResult);
    con.Close();
    GridView2.DataSource = dsResult();
    GridView.DataBind();
