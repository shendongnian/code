    var db = new SqlConnection("Server=localhost; Database=Test; User Id=test; Password=123456;");
    List<SqlDataRecord> users = new List<SqlDataRecord>();
    SqlMetaData mDataFirstName = new SqlMetaData("FirstName", SqlDbType.NVarChar, 50);
    SqlMetaData mDataLastName = new SqlMetaData("LastName", SqlDbType.NVarChar, 50);
            
    SqlDataRecord user1 = new SqlDataRecord(new []{ mDataFirstName, mDataLastName });
    user1.SetString(0, "Ophir");
    user1.SetString(1, "Oren");
    users.Add(user1);
            
    SqlParameter param = new SqlParameter("@Users", SqlDbType.Structured)
    {
        TypeName = "TblUser",
        Value = users
    };
    Dictionary<string, object> values = new Dictionary<string, object>();
    values.Add("@Users", param);
    db.Open();
    using (var command = db.CreateCommand())
    {
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.CommandText = "stp_Users_Insert";
        var p1 = command.CreateParameter();
        command.Parameters.Add(p1);
        p1.ParameterName = "@Users";
        p1.SqlDbType = System.Data.SqlDbType.Structured;
        p1.Value = users;
        command.ExecuteNonQuery();
    }
