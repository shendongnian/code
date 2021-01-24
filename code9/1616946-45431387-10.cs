    IEnumerable<Record> GetRecords()
    {
        // Code to create connection and command (preferably in a using statement)
        SqlDataReader rdrDetail = cmdDetail.ExecuteReader();
        while (rdrDetail.Read())
        {
            yield return new Record {
                System = rdrDetail["name"].ToString(),
                Start = rdrDetail["SysStart"].ToString(),
                End = rdrDetail["SysEnd"].ToString(),
                Capability = rdrDetail["CAPName"].ToString()
            };
        }
        // Close connection (proper using statement will do this)
    }
