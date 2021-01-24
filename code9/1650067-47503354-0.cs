    public void DAL_UpdateStudentsTable(DataTable table) //DAL represents 3-tyer architecture (so data access layer)
    {
      using (SqlConnection sqlConn = new SqlConnection(connString))
      {
        using (SqlCommand cmd = new SqlCommand())
        {
          cmd.CommandText = @"UPDATE Students SET " +
                    "StudentID = @id, " +
                    "FirstName = @first, " +
                    "LastName = @last, " +
                    "Birthday = @birthday, " +
                    "PersonalNo = @personal " +
                    "WHERE StudentID = @oldId";
          cmd.Parameters.Add("@id", SqlDbType.Int, 5, "StudentID");
          cmd.Parameters.Add("@first", SqlDbType.VarChar, 50, "FirstName");
          cmd.Parameters.Add("@last", SqlDbType.VarChar, 50, "LastName");
          cmd.Parameters.Add("@birthday", SqlDbType.DateTime, 1, "Birthday");
          cmd.Parameters.Add("@personal", SqlDbType.VarChar, 50, "PersonalNo");
          SqlParameter param = cmd.Parameters.Add("@oldId", SqlDbType.Int, 5, "StudentID");
          param.SourceVersion = DataRowVersion.Original;
          cmd.Connection = sqlConn;
          using (SqlDataAdapter da = new SqlDataAdapter())
          {
            da.UpdateCommand = cmd;
            da.Update(table);
          }
        }
      }
    }
