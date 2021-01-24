    // dispose the connection after command finished
    using (var localdbm = new DBManager())
    {            
        var sql = sqlBase;
        sql = sql.Replace("#HOUR#", i.ToString());
        using (var reader = db.GetData(sql))
        {
            if (reader.Read())
            {
               //do some stuff
            }
            // no need to close reader
            // as it's being disposed inside using directive
        }
    }
