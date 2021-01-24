    public string Insert_Data(string NewCol1 , string NewCol2, string NewCol3, string NewCol4, double NewCol5)
    {
        try
        {
            con.Open();
            string CheckString = @"SELECT COUNT(*) FROM my_table  " +
                                                   "WHERE col1= '" + NewCol1 + "' " +
                                                   "and col2= '" + NewCol2 + "' " +
                                                   "and col3= '" + NewCol3 + "' " +
                                                   "and col4= '" + NewCol4 + "' ";
            cmd = new SqlCommand(CheckString,con);
            int Count = (int)cmd.ExecuteScalar();
            if (Count > 0)
            {
                return "Record Already Exists.";
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO my_table (col1,col2,col3,col4,col5,getupdateDate) " +
                    " VALUES('" + NewCol1+
                    "','" + NewCol2+
                    "','" + NewCol3 +
                    "','" + NewCol4+
                    "'," + NewCol5+ ", GETDATE())", con);
                int temp = cmd.ExecuteNonQuery();
                return "Inserted Sucessfully";
            }
        }
        finally
        {
            con.Close();
        }
    }
