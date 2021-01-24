    string cmdText = @"IF EXISTS(Select 1 from dbo.Admin 
                                 where Type=2 and UserName=@user)
                                 SELECT 1 ELSE SELECT 0";
    using(SqlConnection myConn = new SqlConnection(myConnection))
    using(SqlCommand SelectCommand = new SqlCommand(cmdText, myConn))
    {
        myConn.Open();
        SelectCommand.Parameters.Add("@user", SqlDbType.NVarChar).Value = l1.UserName.Text;
        int i = (int)SelectCommand.ExecuteScalar();
        if (i > 0)
        { 
            btnAdminPanel.Hide();
        }
    }
