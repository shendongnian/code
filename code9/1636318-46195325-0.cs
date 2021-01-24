    var parameters = new List<SqlParameter> {
        new SqlParameter("@username", username) 
    };
    string query = "Select PasswordHash From Users where Username = @username";
    string hash = db.Database.SqlQuery<string>(query, parameters.ToArray()).FirstOrDefault<string>();
