    string selectQuery = "SELECT * FROM Students WHERE firstName=@first and lastName=@last";
    using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
    {
        sqlCommand.Parameters.Add("@first", SqlDbType.VarChar);
        sqlCommand.Parameters.Add("@last", SqlDbType.VarChar);
        foreach (Student student in studentList) // addds 100 students
        {
            // overwrites the same parameter again and again.... so its only the last one
            sqlCommand.Parameters["@first"].Value = student.first;
            sqlCommand.Parameters["@last"].Value = student.last;
        }
        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader()) 
        {// the query uses only 2 params so you need to change the query and the adding
            while (sqlReader.Read())
            {
                Console.WriteLine(sqlReader["firstName"].ToString());
                Console.WriteLine(sqlReader["lastName"].ToString());
            }
        }
          
