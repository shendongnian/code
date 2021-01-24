    protected void OnUpdate(object sender, EventArgs e)
{
    string StrConnString = ConfigurationManager.ConnectionStrings["BenzConnectionString"].ToString();
    SqlConnection objConn = new SqlConnection(StrConnString);
    try
    {
        objConn.Open();
        using(SqlCommand objCmd1 = new SqlCommand("UPDATE  Employee SET FirstName =  @sFirstName," +
            " LastName = @sLastName," +
            " EMail = @sEMail, " +
            "PhoneNo = @sPhoneNo, " +
            "PositionID = @sPositionID, " +
            "DepartmentID = @sDepartmentID" +
            " WHERE  EmployeeID = @sEmployeeID", objConn){
        objCmd.Parameters.AddWithValue("@sFirstName", txtfirstname.Text);
        objCmd.Parameters.AddWithValue("@sLastName", txtlastname.Text);
        objCmd.Parameters.AddWithValue("@sEMail", txtemail.Text);
        objCmd.Parameters.AddWithValue("@sPhoneNo", txtphone.Text);
        objCmd.Parameters.AddWithValue("@sPositionID", dpposition.Text);
        objCmd.Parameters.AddWithValue("@sDepartmentID", dpcenter.Text);
        objCmd.Parameters.AddWithValue("@sEmployeeID", empno);
        objCmd.ExecuteNonQuery();
