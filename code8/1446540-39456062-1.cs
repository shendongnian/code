    using (var context = new SqlConnection())
    {
          var cmd = new SqlCommand
          {
              CommandText = "SELECT * FROM Table",
              CommandType = CommandType.Text,
              Connection = context
          };
          context.Open();
          var reader = cmd.ExecuteReader();
          reader.Close();
      }
