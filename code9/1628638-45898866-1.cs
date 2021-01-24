    public int RunOracleTransaction(Student s, Marks[] m, Course[] c) {
      //TODO: validate s, m, c
      using (OracleConnection connection = new OracleConnection(connectionString)) {
        connection.Open();
    
        using (OracleCommand command = connection.CreateCommand()) {
          using (OracleTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)) {
            command.Transaction = transaction;
    
            try {
              // Insert the student
              //TODO: put actual query here 
              command.CommandText = 
                @"insert into Students(name)
                       values (:prm_Name)
                    returning id into :prm_id"; // <- we want inserted student's id
    
              //TODO: check actual RDBMS types 
              command.Parameters.Add(":prm_Name", OracleType.VarChar).Value = s.Name;
              command.Parameters.Add(":prm_Id", OracleType.VarChar).Direction = ParameterDirection.Output;
             
              command.ExecuteNonQuery(); 
    
              string studentId = Convert.ToString(comm.Parameters[":prm_Id"].Value);
             
              // Insert his/her marks
              command.Parameters.Clear(); // <- forget all prior parameters
    
              //TODO: put actual query here 
              command.CommandText = 
                @"insert into StudentsMarks(student_Id, mark)
                       values (:prm_Student_Id, :prm_Mark)";
    
              //TODO: check actual RDBMS types 
              command.Parameters.Add(":prm_Student_Id", OracleType.VarChar).Value = studentId;
              command.Parameters.Add(":prm_Mark", OracleType.Int32);
              
              // insert each mark (in a loop)
              foreach (var mark in m) {
                command.Parameters[":prm_Mark"].Value = m.Mark;
                command.ExecuteNonQuery();  
              }
    
              // Finally, commit all the inserts
              transaction.Commit();
            }
            catch (DataException e) {
              transaction.Rollback();
    
              Console.WriteLine(e.ToString());
              Console.WriteLine("Neither record was written to database.");
            }
          }
        } 
      }
      //TODO: your method returns integer value, please return it  
    }
