    public static SqlParameter NewSqlParameter(string parameterName, SqlDbType dbType, object value)
    {
        SqlParameters sqlParameter = new SqlParameter(parametersName, dbType);
        sqlParameter.Value = value;
        return sqlParameter;
    }
    public int InsertEmployee(string Fname, char Minit, string Lname, int SSN, int? Salary)
    {
        return model.ExecuteNonQuery(
            @"
                INSERT INTO Employee (
                           Fname, Minit, Lname, SSN, Salary
                       ) VALUES (
                           @Fname, @Minit, @Lname, @SSN, @Salary
                       )
            ",
            NewSqlParameter("@Fname",  SqlDbType.VarChar, Fname),
            NewSqlParameter("@Minit",  SqlDbType.VarChar, Minit),
            NewSqlParameter("@Lname",  SqlDbType.VarChar, Lname),
            NewSqlParameter("@SSN",    SqlDbType.Int,     SSN),
            NewSqlParameter("@Salary", SqlDbType.Int,     Salary));
    }
