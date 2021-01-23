    var parameters = new List<SqlParameter>();
    string statement = "exec uspPersonAdd @personName = @name, @activeFlag = @active";
    parameters.Add(new SqlParameter("@name", person.PersonName));
    parameters.Add(new SqlParameter("@active", person.Active));
    int id = ExecuteSqlCount(statement, parameters.ToArray());
