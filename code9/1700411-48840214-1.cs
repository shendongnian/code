    string selectQuery = "SELECT * FROM Students WHERE firstName = @first AND lastName = @last";
    using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
    {
        sqlCommand.Parameters.Add("@first", SqlDbType.VarChar);
        sqlCommand.Parameters.Add("@last", SqlDbType.VarChar);
    
        foreach (Student student in studentList)
        {
            sqlCommand.Parameters["@first"].Value = student.first;
            sqlCommand.Parameters["@last"].Value = student.last;
            using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
            {
                 while (sqlReader.Read())
                 {
                     Console.WriteLine(sqlReader["firstName"].ToString());
                     Console.WriteLine(sqlReader["lastName"].ToString());
                 }
            }
        }
    }
