    public DataTable GetAllEmployeesFromEmp()
    {
        SqlConnection vConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        vConn.Open();
        String vQuery = "Select * from Employee";
        SqlDataAdapter vAdap = new SqlDataAdapter(vQuery, vConn);
        DataSet vDs = new DataSet();
        vAdap.Fill(vDs, "Employee");
        vConn.Close();
        DataTable vDt = vDs.Tables[0];
        return vDt;
    }
