     public async Task<User> AddUserAsync(UserAdd user) 
     {
        using (var connection = _connectionFactory.Create() 
          {
             var result = connection.ExecuteAsync("dbo.AddUser", user.GetParameters(), commandType: CommandType.StoredProcedure";
             return result;
          }
      }
