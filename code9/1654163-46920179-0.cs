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
            new SqlParameter("@Fname",  Fname),
            new SqlParameter("@Minit",  Minit),
            new SqlParameter("@Lname",  Lname),
            new SqlParameter("@SSN",    SSN),
            new SqlParameter("@Salary", Salary));
    }
