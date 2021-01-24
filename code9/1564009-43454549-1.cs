      ...
      catch (MySqlException ex)
      {
         if (/*ex is a connection drop */) {
            Connection?.Dispose();
            Connection = new MySqlConnection(...);
            Connection.ConnectionString = /* your connection string */;
            Connection.Open();
         }
         else {
            throw;
         }
      }
