      string sql = 
         $@"UPDATE Room
               SET [{Time}] = 0
             WHERE [Day] = @prm_Day";
      // Providing that you use MS SQL - SqlCommand
      using (SqlCommand q = new SqlCommand(sql, MyConnection)) {
        //TODO: Check the actual RDMBS type - is it SqlDbType.DateTime? 
        q.Parameters.Add("@prm_Day", SqlDbType.DateTime).Value = Day;
        q.ExecuteNonQuery();
      }
