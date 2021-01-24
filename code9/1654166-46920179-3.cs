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
            new SqlParameter("@Fname",  SqlDbType.VarChar) { Value = Fname  },
            new SqlParameter("@Minit",  SqlDbType.VarChar) { Value = Minit  },
            new SqlParameter("@Lname",  SqlDbType.VarChar) { Value = Lname  },
            new SqlParameter("@SSN",    SqlDbType.Int    ) { Value = SSN    },
            new SqlParameter("@Salary", SqlDbType.Int    ) { Value = Salary.HasValue ? (object) Salary : System.DBNull.Value });
    }
	
