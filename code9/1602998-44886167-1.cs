    private List<int> GetSubGroupsBelongingToUser()
    {
        List<int> list = new List<int>();
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["FSK_ServiceMonitor_Users_Management.Properties.Settings.FSK_ServiceMonitorConnectionString"].ConnectionString))
        using (var cmd = new SqlCommand("Test", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            var param = new SqlParameter("@UserId", SqlDbType.Int).Value = int.Parse(cbxSelectUser.Text);
            cmd.Parameters.Add(param);
            con.Open();
            using (var rd = cmd.ExecuteReader())
            {
                while (rd.Read()) list.Add(rd.GetInt32(0)); 
            }
        } // no need to close the connection with the using
        return list;
    }
