    // Let's extract a class: it should provide us standard cursors, 
    // e.g. Protfolio Names 
    public static class MyData {
      // Let's enumerate items returned
      public static IEnumerable<string> PortfolioNames() {
        // Wrap IDisposable into using
        //TODO: move Connection String into a separated method/property 
        using (SqlConnection con = new SqlConnection(/*connection string here*/)) {
          con.Open();
          // Make sql readable 
          string sql = 
            @"select Portfolio_Name
                from Dbo.Name
               where In_use = 1"; 
          // Wrap IDisposable into using
          using (SqlCommand q = new SqlCommand(sql, con)) {
            // Wrap IDisposable into using 
            using (var reader = q.ExecuteReader()) {
              while (reader.Read())
                yield return Convert.ToString(reader[0]);
            }
          }
        }
      }
    }  
