    string sql = "Select Name,Father_name,NIC_No,Image from Admform WHERE Member_ID=@memid";.
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
        var memidParam = new SqlParameter("memid", SqlDbType.Int);
        memidParam.Value = textBoxmember.Text;
    
        command.Parameters.Add(memidParam);
        var results = command.ExecuteReader();
    }
