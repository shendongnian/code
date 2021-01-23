    string strcon =  System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    using (var connection = new SqlConnection(strcon)) {
        using (var command = new SqlCommand("usp_InserUpadte", connection)) {
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add("@Account_TT ", SqlDbType.NVarChar).Value = ACC;
          command.Open();
          var reader = command.ExecuteReader();
          // Handle return data here
        }
      }
