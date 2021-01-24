    using using Dapper.Contrib.Extensions; //Git
    public async Task SaveChangesAsync(IList<MyEntity> myEntityValues)
    {
         var conn = new SqlConnection(myconnectionString);
         if(conn.State != ConnectionState.Open)
             conn.Open();
         await conn.InsertAsync(myEntityValues);
         if (conn.State != ConnectionState.Closed)
         {
            conn.Close();
            conn.Dispose();
          }
    }
