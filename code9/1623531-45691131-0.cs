      string sql = 
         $@"UPDATE Room
               SET [{Time}] = 0
             WHERE [Day] = @prm_Day";
      // Providing that you use MS SQL - SqlCommand
      using (SqlCommand q = new SqlCommand(sql, MyConnection)) {
        q.Parameters.AddWithValue("@prm_Day", Day);
        q.ExecuteNonQuery();
      }
