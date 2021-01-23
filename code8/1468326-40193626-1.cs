    using (var connection = new SqlConnection(_connection))
    {
            var result = connection.Query<TUser, IdentityProfile, TUser>
            ("IdentityGetUserById", 
             commandType: CommandType.StoredProcedure,
             (user, profile) => 
                            { 
                               user.Profile = profile;
                               return user; 
                            }, new { userId }, 
                           splitOn: "UserId").SingleOrDefault();
              return Task.FromResult(result);
             );
    }
