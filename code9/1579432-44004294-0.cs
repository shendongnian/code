    public void SomeFunction()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_AddPublisher", con);
        cmd.CommandText = "usp_AddPublisher";
        cmd.CommandType = CommandType.StoredProcedure;
        SwitchFunction(data.Account_Num, "@AccountNum", cmd);
        SwitchFunction(data.publisher, "@publisher", cmd);
        SwitchFunction(data.addr1, "@addr1", cmd);
    }
    public void SwitchFunction(string testVar, string withVal, SqlCommand cmd)
    {
        switch (String.IsNullOrEmpty(testVar))
        {
            case true:
                cmd.Parameters.AddWithValue(withVal, string.Empty);
                break;
            case false:
                cmd.Parameters.AddWithValue(withVal, testVar);
                break;
        }
    }
