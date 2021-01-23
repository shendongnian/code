    string sql = "SELECT MAX(ASD.eventDateTime) AS second, R.resourceID, R.resourceLoginID, ASD.agentID FROM AgentStateDetail AS ASD INNER JOIN Resource AS R ON ASD.agentID = R.ResourceID WHERE ASD.eventDateTime >= @dateTimeStart AND ASD.eventDateTime <= @dateTimeEnd GROUP BY R.ResourceID,R.resourceLoginID,ASD.agentID";
    
    using (SqlConnection connection = new SqlConnection(/* connection info */))
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
        var dateTimeStart = new SqlParameter("dateTimeStart", SqlDbType.DateTime);
        dateTimeStart.Value = new DateTime("yyyy-MM-dd h:mm:ss");
        var dateTimeEnd = new SqlParameter("dateTimeEnd", SqlDbType.DateTime);
        dateTimeEnd.Value = new DateTime("yyyy-MM-dd h:mm:ss");
    
        command.Parameters.Add(dateTimeStart);
        command.Parameters.Add(dateTimeEnd);
        var results = command.ExecuteReader();
    }
