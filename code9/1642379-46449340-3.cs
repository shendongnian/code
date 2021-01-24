    DateTime timeIn;
    // Still prefer to use TryParseExact....
    if(DateTime.TryParse(textBox2.Text, out timeIn))
    {
        var query = "INSERT INTO Person (Name,Organisation,TimeIn) VALUES(@Name, @Organisation, @TimeIn)";
        var parameters = new IDbDataParameter[]
        {
            _DB.CreateParameter("@Name", ADONETType.NVarChar, textBox1.Text),
            _DB.CreateParameter("@Organisation", ADONETType.NVarChar, textBox3.Text),
            _DB.CreateParameter("@TimeIn", ADONETType.DateTime, timeIn)
        };
        _DB.ExecuteNonQuery(query, CommandType.Text, parameters);
    }
