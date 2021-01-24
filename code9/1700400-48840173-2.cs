    // public class Student { public string first; public string last; }
    
    // demo-data - you dont need those
    var studentList = Enumerable.Range(10, 110)
        .Select(i => new Student { first = $"firstname {i}", 
                                   last = $"lastname {i}" })
        .ToList();
    // create all the variable names
    var firstVarName = Enumerable.Range(1, studentList.Count)
        .Select(i => $"@first_{i}").ToList();
    var lastVarName = Enumerable.Range(1, studentList.Count)
        .Select(i => $"@last_{i}").ToList(); 
    // adapt query to search all variable names with `in` clause
    string selectQuery = $@"
    SELECT * 
    FROM Students 
    WHERE firstName in ( {string.Join(",",firstVarName)} ) 
      and lastName  in ( {string.Join(",",lastVarName)} )";
    
    using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
    {
        sqlCommand.Parameters.Add("@first", SqlDbType.VarChar);
        sqlCommand.Parameters.Add("@last", SqlDbType.VarChar);
        // add all the variable names with values from list
        for(int i=0;i<studentList.Count;i++) 
        {
            sqlCommand.Parameters[firstVarName[i]].Value = studentList[i].first;
            sqlCommand.Parameters[lastVarName[i]].Value = studentList[i].last;
        }
        using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
        { 
            while (sqlReader.Read())
            {
                Console.WriteLine(sqlReader["firstName"].ToString());
                Console.WriteLine(sqlReader["lastName"].ToString());
            }
        }
    }
 
   
